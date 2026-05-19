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
    public class ProfessoresController : ControllerBase
    {
        private IAdicionarProfessoresUseCase adicionarProfessoresUseCase;
        private IAtualizarProfessoresUseCase atualizarProfessoresUseCase;
        private IExcluirProfessorUseCase excluirProfessorUseCase;
        private IProfessorRepositorio professorRepositorio;

        public ProfessoresController(IAdicionarProfessoresUseCase adicionarProfessoresUseCase, IAtualizarProfessoresUseCase atualizarProfessoresUseCase, IExcluirProfessorUseCase excluirProfessorUseCase, IProfessorRepositorio professorRepositorio)
        {
            this.adicionarProfessoresUseCase = adicionarProfessoresUseCase;
            this.atualizarProfessoresUseCase = atualizarProfessoresUseCase;
            this.excluirProfessorUseCase = excluirProfessorUseCase;
            this.professorRepositorio = professorRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AtualizarProfessorRequest request)
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
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarProfessorRequest request)
        {
            try
            {
                Professor professor = new()
                {
                    nome = request.nome,
                    email = request.email
                };

                await atualizarProfessoresUseCase.AtualizarProfessor(professor);
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
                List<Professor> professores = await professorRepositorio.ObterTodosOsProfessores();

                List<ProfessorResponse> professoresResponse = professores.Select(p => new ProfessorResponse()
                {
                    id = p.id,
                    nome = p.nome,
                    email = p.email
                }).ToList();
                return Ok(professoresResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}