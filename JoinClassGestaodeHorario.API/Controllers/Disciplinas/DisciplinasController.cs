using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Disciplinas.Request;
using JoinClassGestaodeHorario.API.Controllers.Disciplinas.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Disciplinas
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinasController : ControllerBase
    {
        private IDisciplinaRepositorio disciplinaRepositorio;
        private ICriarDisciplinaUseCase criarDisciplinaUseCase;
        private IAtualizarDisciplinaUseCase atualizarDisciplinaUseCase;
        private IExcluirDisciplinaUseCase excluirDisciplinaUseCase;

        public DisciplinasController(IDisciplinaRepositorio disciplinaRepositorio, ICriarDisciplinaUseCase criarDisciplinaUseCase, IAtualizarDisciplinaUseCase atualizarDisciplinaUseCase, IExcluirDisciplinaUseCase excluirDisciplinaUseCase)
        {
            this.disciplinaRepositorio = disciplinaRepositorio;
            this.criarDisciplinaUseCase = criarDisciplinaUseCase;
            this.atualizarDisciplinaUseCase = atualizarDisciplinaUseCase;
            this.excluirDisciplinaUseCase = excluirDisciplinaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CriarDisciplinaRequest request)
        {
            try
            {
                Disciplina disciplina = new()
                {
                    nome = request.nome,
                    cargaHoraria = request.cargaHoraria
                };
                await criarDisciplinaUseCase.CadastrarDisciplina(disciplina);

                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarDisciplinasRequest request)
        {
            try
            {
                Disciplina disciplina = new()
                {
                    nome = request.nome,
                    cargaHoraria = request.cargaHoraria
                };
                await atualizarDisciplinaUseCase.AtualizarDisciplina(disciplina);

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
                await excluirDisciplinaUseCase.ExcluirDisciplina(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterDisciplinas()
        {
            try
            {
                List<Disciplina> disciplinas = await disciplinaRepositorio.ObterTodasAsDisciplinas();

                List<DisciplinaResponse> disciplinasResponse = disciplinas.Select(d => new DisciplinaResponse()
                {
                    id = d.id,
                    nome = d.nome,
                    cargaHoraria = d.cargaHoraria
                }).ToList();

                return Ok(disciplinasResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}