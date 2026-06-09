using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Turmas.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Turmas.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Turmas.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Turmas.Request;
using JoinClassGestaodeHorario.API.Controllers.Turmas.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Turmas
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase
    {
        private ITurmaRepositorio turmaRepositorio;
        private ICriarTurmaUseCase criarTurmaUseCase;
        private IAtualizarTurmaUseCase atualizarTurmaUseCase;
        private IExcluirTurmaUseCase excluirTurmaUseCase;

        public TurmasController(ITurmaRepositorio turmaRepositorio, ICriarTurmaUseCase criarTurmaUseCase, IAtualizarTurmaUseCase atualizarTurmaUseCase, IExcluirTurmaUseCase excluirTurmaUseCase)
        {
            this.turmaRepositorio = turmaRepositorio;
            this.criarTurmaUseCase = criarTurmaUseCase;
            this.atualizarTurmaUseCase = atualizarTurmaUseCase;
            this.excluirTurmaUseCase = excluirTurmaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CriarTurmaRequest request)
        {
            try
            {
                Turma turma = new()
                {
                    id_professor = request.id_professor
                };
                await criarTurmaUseCase.CadastrarTurma(turma);

                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarTurmaRequest request)
        {
            try
            {
                Turma turma = new()
                {
                    id = id,
                    id_professor = request.id_professor
                };
                await atualizarTurmaUseCase.AtualizarTurma(turma);

                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            try
            {
                await excluirTurmaUseCase.ExcluirTurma(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTurmas()
        {
            try
            {
                List<Turma> turmas = await turmaRepositorio.ObterTodasAsTurmas();

                List<TurmaResponse> turmasResponse = turmas.Select(t => new TurmaResponse()
                {
                    id = t.id,
                    id_professor = t.id_professor
                }).ToList();

                return Ok(turmasResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}