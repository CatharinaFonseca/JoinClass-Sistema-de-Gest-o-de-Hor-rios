using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Request;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Pessoas
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoasController : ControllerBase
    {
        private IAdicionarPessoaUseCase adicionarPessoaUseCase;
        private IAtualizarPessoaUseCase atualizarPessoaUseCase;
        private IExcluirPessoaUseCase excluirPessoaUseCase;
        private IPessoaRepositorio pessoaRepositorio;


        public PessoasController(IExcluirPessoaUseCase excluirPessoaUseCase, IAtualizarPessoaUseCase atualizarPessoaUseCase, IAdicionarPessoaUseCase adicionarPessoaUseCase, IPessoaRepositorio pessoaRepositorio)
        {
            this.excluirPessoaUseCase = excluirPessoaUseCase;
            this.atualizarPessoaUseCase = atualizarPessoaUseCase;
            this.adicionarPessoaUseCase = adicionarPessoaUseCase;
            this.pessoaRepositorio = pessoaRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] AdicionarPessoaRequest request)
        {
            try
            {
                Pessoa pessoa = new()
                {
                    nome = request.nome,
                    email = request.email,
                    senha = request.senha
                };
                await adicionarPessoaUseCase.AdicionarPessoa(pessoa);

                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarPessoaRequest request)
        {
            try
            {
                Pessoa pessoa = new()
                {
                    nome = request.nome,
                    email = request.email,
                    senha = request.senha
                };
                await atualizarPessoaUseCase.AtualizarPessoa(pessoa);

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
                await excluirPessoaUseCase.ExcluirPessoa(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterPessoas()
        {
            try
            {
                List<Pessoa> pessoas = await pessoaRepositorio.ObterTodasAsPessoas();

                List<PessoaResponse> pessoasResponse = pessoas.Select(p => new PessoaResponse()
                {
                    id = p.id,
                    nome = p.nome,
                    email = p.email,
                    senha = p.senha
                }).ToList();

                return Ok(pessoasResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("debug")]
        public async Task<IActionResult> Debug()
        {
            return Ok(await pessoaRepositorio.ObterTodasAsPessoas());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdicionarPessoaRequest login)
        {
            var todos = await pessoaRepositorio.ObterTodasAsPessoas();
            return Ok(todos);
        }
    }
}