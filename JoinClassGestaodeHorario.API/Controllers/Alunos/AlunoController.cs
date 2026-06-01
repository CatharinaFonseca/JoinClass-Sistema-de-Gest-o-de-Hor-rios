using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Alunos.Request;
using JoinClassGestaodeHorario.API.Controllers.Alunos.Response;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Request;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Alunos
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private IAdicionarAlunoUseCase adicionarAlunoUseCase;
        private IAtualizarAlunoUseCase atualizarAlunoUseCase;
        private IExcluirAlunoUseCase excluirAlunoUseCase;
        private IAlunoRepositorio alunoRepositorio;

        public AlunosController(IAdicionarAlunoUseCase adicionarAlunoUseCase, IAtualizarAlunoUseCase atualizarAlunoUseCase, IExcluirAlunoUseCase excluirAlunoUseCase, IAlunoRepositorio alunoRepositorio)
        {
            this.adicionarAlunoUseCase = adicionarAlunoUseCase;
            this.atualizarAlunoUseCase = atualizarAlunoUseCase;
            this.excluirAlunoUseCase = excluirAlunoUseCase;
            this.alunoRepositorio = alunoRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarAlunoRequest request)
        {
            try
            {
                Aluno aluno = new()
                {
                    nome = request.nome,
                    email = request.email
                };

                await adicionarAlunoUseCase.CadastrarAluno(aluno);
                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarAlunoRequest request)
        {
            try
            {
                Aluno aluno = new()
                {
                    id = id,
                    nome = request.nome,
                    email = request.email
                };

                await atualizarAlunoUseCase.AtualizarAluno(aluno);
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
                await excluirAlunoUseCase.ExcluirAluno(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterAluno([FromRoute] int id)
        {
            try
            {
                Aluno aluno = await alunoRepositorio.ObterAluno(id);

                if (aluno == null)
                    return NotFound();

                AlunoResponse response = new()
                {
                    id = aluno.id,
                    nome = aluno.nome,
                    email = aluno.email
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var alunos = await alunoRepositorio.ObterTodosOsAlunos();

                var response = alunos.Select(a => new AlunoResponse
                {
                    id = a.id,
                    nome = a.nome,
                    email = a.email
                }).ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}