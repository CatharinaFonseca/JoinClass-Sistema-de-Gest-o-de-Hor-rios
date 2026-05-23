using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.AtualizarGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacaoUseCase;
using JoinClassGestaodeHorario.API.Controllers.Graduacoes.Request;
using JoinClassGestaodeHorario.API.Controllers.Graduacoes.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes
{
    [ApiController]
    [Route("api/[controller]")]
    public class GraduacoesController : ControllerBase
    {
        private ICriarGraduacaoUseCase criarGraduacaoUseCase;
        private IAtualizarGraduacaoUseCase atualizarGraduacaoUseCase;
        private IExcluirGraduacaoUseCase excluirGraduacao;
        private IGraduacaoRepositorio graduacaoRepositorio;

        public GraduacoesController(ICriarGraduacaoUseCase criarGraduacaoUseCase, IAtualizarGraduacaoUseCase atualizarGraduacaoUseCase, IExcluirGraduacaoUseCase excluirGraduacao, IGraduacaoRepositorio graduacaoRepositorio)
        {
            this.criarGraduacaoUseCase = criarGraduacaoUseCase;
            this.atualizarGraduacaoUseCase = atualizarGraduacaoUseCase;
            this.excluirGraduacao = excluirGraduacao;
            this.graduacaoRepositorio = graduacaoRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CriarGraduacaoRequest request)
        {
            try
            {
                Graduacao graduacao = new()
                {
                    nome = request.nome,
                    cargaHoraria = request.cargaHoraria,
                    duracao = request.duracao,
                    qntAulas = request.qntAulas
                };
                await criarGraduacaoUseCase.CadastrarGraduacao(graduacao);

                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarGraduacaoRequest request)
        {
            try
            {
                Graduacao graduacao = new()
                {
                    nome = request.nome,
                    cargaHoraria = request.cargaHoraria,
                    duracao = request.duracao,
                    qntAulas = request.qntAulas
                };
                await atualizarGraduacaoUseCase.AtualizarGraduacao(graduacao);

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
                //Não precisa ter objeto
                await excluirGraduacao.ExcluirGraduacao(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterGraduacoes()
        {
            try
            {
                List<Graduacao> graduacoes = await graduacaoRepositorio.ObterTodasAsGraduacoes();

                List<GraduacaoResponse> graduacoesresponse = graduacoes.Select(g => new GraduacaoResponse()
                {
                    id = g.id,
                    nome = g.nome,
                    cargaHoraria = g.cargaHoraria,
                    duracao = g.duracao,
                    qntAulas = g.qntAulas
                }).ToList();

                return Ok(graduacoes);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}