using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Professores.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Professores.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Professores.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Professores.Request;
using JoinClassGestaodeHorario.API.Controllers.Professores.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Professores
{
    [ApiController]
    [Route("api/professores")]
    public class ProfessoresController : ControllerBase
    {
        private IAdicionarProfessoresUseCase adicionarProfessoresUseCase;
        private IAtualizarProfessoresUseCase atualizarProfessoresUseCase;
        private IExcluirProfessorUseCase excluirProfessorUseCase;
        private IProfessorRepositorio professorRepositorio;
        private readonly ILogger<ProfessoresController> _logger;

        public ProfessoresController(IAdicionarProfessoresUseCase adicionarProfessoresUseCase, IAtualizarProfessoresUseCase atualizarProfessoresUseCase, IExcluirProfessorUseCase excluirProfessorUseCase, IProfessorRepositorio professorRepositorio, ILogger<ProfessoresController> logger)
        {
            this.adicionarProfessoresUseCase = adicionarProfessoresUseCase;
            this.atualizarProfessoresUseCase = atualizarProfessoresUseCase;
            this.excluirProfessorUseCase = excluirProfessorUseCase;
            this.professorRepositorio = professorRepositorio;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarProfessorRequest request)
        {
            try
            {
                Professor professor = new()
                {
                    nome = request.nome,
                    email = request.email
                };

                await adicionarProfessoresUseCase.CadastrarProfessor(professor);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar professor");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizaProfessorRequest request)
        {
            try
            {
                Professor professor = new()
                {
                    id = id,
                    nome = request.nome,
                    email = request.email
                };

                await atualizarProfessoresUseCase.AtualizarProfessor(professor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            try
            {
                await excluirProfessorUseCase.ExcluirProfessor(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProfessor([FromRoute] int id)
        {
            try
            {
                var professor = await professorRepositorio.ObterProfessor(id);

                if (professor == null)
                    return NotFound();

                var response = new ProfessorResponse
                {
                    id = professor.id,
                    nome = professor.nome,
                    email = professor.email
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var professores = await professorRepositorio.ObterTodosOsProfessores();

                var response = professores.Select(p => new ProfessorResponse
                {
                    id = p.id,
                    nome = p.nome,
                    email = p.email
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}