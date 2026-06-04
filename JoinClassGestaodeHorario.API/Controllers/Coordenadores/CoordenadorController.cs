using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Coordenadores.Request;
using JoinClassGestaodeHorario.API.Controllers.Coordenadores.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Coordenadores
{
<<<<<<< HEAD
=======
    [ApiController]
    [Route("api/coordenadores")]
>>>>>>> feature/Gabriela
    public class CoordenadoresController : ControllerBase
    {
        private IAdicionarCoordenadoresUseCase adicionarCoordenadoresUseCase;
        private IAtualizarCoordenadoresUseCase atualizarCoordenadoresUseCase;
        private IExcluirCoordenadorUseCase excluirCoordenadorUseCase;
        private ICoordenadorRepositorio coordenadorRepositorio;
        public CoordenadoresController(IAdicionarCoordenadoresUseCase adicionarCoordenadoresUseCase, IAtualizarCoordenadoresUseCase atualizarCoordenadoresUseCase, IExcluirCoordenadorUseCase excluirCoordenadorUseCase, ICoordenadorRepositorio coordenadorRepositorio)
        {
            this.adicionarCoordenadoresUseCase = adicionarCoordenadoresUseCase;
            this.atualizarCoordenadoresUseCase = atualizarCoordenadoresUseCase;
            this.excluirCoordenadorUseCase = excluirCoordenadorUseCase;
            this.coordenadorRepositorio = coordenadorRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarCoordenadorRequest request)
        {
            try
            {
                Coordenador coordenador = new()
                {
                    nome = request.nome,
                    email = request.email
                };

                await adicionarCoordenadoresUseCase.CadastrarCoordenador(coordenador);
                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarCoordenadorRequest request)
        {
            try
            {
                Coordenador coordenador = new()
                {
                    id = id,
                    nome = request.nome,
                    email = request.email
                };

                await atualizarCoordenadoresUseCase.AtualizarCoordenador(coordenador);
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
                await excluirCoordenadorUseCase.ExcluirCoordenador(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCoordenador([FromRoute] int id)
        {
            try
            {
                Coordenador coordenador = await coordenadorRepositorio.ObterCoordenador(id);

                if (coordenador == null)
                    return NotFound();

                CoordenadorResponse response = new()
                {
                    id = coordenador.id,
                    nome = coordenador.nome,
                    email = coordenador.email
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}