using System;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Controllers.Disciplinas.Request;
using JoinClassGestaodeHorario.API.Dados;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Controllers.ProfessoresDiciplinas.Request;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.ProfessoresDiciplinas
{
    [ApiController]
    [Route("api/professor-disciplina")]
    public class ProfessorDisciplinaController : ControllerBase
    {
        private readonly ApplicationDbContext _contexto;

        // O construtor recebe o acesso ao banco de dados Neon
        public ProfessorDisciplinaController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost("vincular")]
        public async Task<IActionResult> VincularProfessor([FromBody] VincularProfessorDisciplinaRequest request)
        {
            try
            {
                ProfessorDisciplina vinculo = new()
                {
                    id_professor = request.id_professor,
                    id_disciplina = request.id_disciplina
                };

                _contexto.ProfessorDisciplinas.Add(vinculo);
                await _contexto.SaveChangesAsync();

                return Created("", new { mensagem = "Professor vinculado à disciplina com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "Erro ao vincular: " + ex.Message });
            }
        }
    }
}