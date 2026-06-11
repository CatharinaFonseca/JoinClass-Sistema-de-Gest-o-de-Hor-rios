using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Controllers.MatrizesCurriculares.Request;
using JoinClassGestaodeHorario.API.Controllers.MatrizesCurriculares.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using JoinClassGestaodeHorario.API.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.MatrizesCurriculares
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatrizCurricularController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatrizCurricularController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<MatrizResponse>> Criar([FromBody] CriarMatrizRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var novaMatriz = new MatrizCurricular
            {
                id_graduacao = request.id_graduacao,
                id_semestre = request.id_semestre,
                id_disponibilidade = request.id_disponibilidade,
                id_disciplina = request.id_disciplina
            };

            _context.MatrizesCurriculares.Add(novaMatriz);
            await _context.SaveChangesAsync();

            await _context.Entry(novaMatriz).Reference(m => m.Graduacao).LoadAsync();
            await _context.Entry(novaMatriz).Reference(m => m.Semestre).LoadAsync();
            await _context.Entry(novaMatriz).Reference(m => m.Disciplina).LoadAsync();

            var response = MapearParaResponse(novaMatriz);

            return CreatedAtAction(nameof(ObterPorId), new { id = response.id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarMatrizRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var matrizExistente = await _context.MatrizesCurriculares.FindAsync(id);
            if (matrizExistente == null)
            {
                return NotFound(new { mensagem = "Matriz curricular não encontrada." });
            }

            matrizExistente.id_graduacao = request.id_graduacao;
            matrizExistente.id_semestre = request.id_semestre;
            matrizExistente.id_disponibilidade = request.id_disponibilidade;
            matrizExistente.id_disciplina = request.id_disciplina;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatrizCurricularExiste(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var matriz = await _context.MatrizesCurriculares.FindAsync(id);
            if (matriz == null) return NotFound(new { mensagem = "Matriz curricular não encontrada." });

            _context.MatrizesCurriculares.Remove(matriz);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Matriz Curricular eliminada com sucesso." });
        }

        private bool MatrizCurricularExiste(int id)
        {
            return _context.MatrizesCurriculares.Any(e => e.id == id);
        }

        private static MatrizResponse MapearParaResponse(MatrizCurricular matriz)
        {
            return new MatrizResponse
            {
                id = matriz.id,
                id_graduacao = matriz.id_graduacao,
                id_semestre = matriz.id_semestre,
                id_disponibilidade = matriz.id_disponibilidade,
                id_disciplina = matriz.id_disciplina,
                nome_disciplina = matriz.Disciplina?.nome
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatrizResponse>>> ObterTodos()
        {
            var matrizes = await _context.MatrizesCurriculares
                .Include(m => m.Graduacao)
                .Include(m => m.Semestre)
                .Include(m => m.Disciplina)
                .ToListAsync();

            var response = matrizes.Select(m => MapearParaResponse(m)).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatrizResponse>> ObterPorId(int id)
        {
            var matriz = await _context.MatrizesCurriculares
                .Include(m => m.Graduacao)
                .Include(m => m.Semestre)
                .Include(m => m.Disciplina)
                .FirstOrDefaultAsync(m => m.id == id);

            if (matriz == null)
            {
                return NotFound(new { mensagem = $"Matriz Curricular com ID {id} não encontrada." });
            }

            return Ok(MapearParaResponse(matriz));
        }
    }
}