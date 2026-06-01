using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Horarios.Request;
using JoinClassGestaodeHorario.API.Controllers.Horarios.Response;
using JoinClassGestaodeHorario.API.Dados;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Controllers.Horarios
{

    [ApiController]
    [Route("api/[controller]")]
    public class HorarioController : ControllerBase
    {
        private IHorarioRepositorio horarioRepositorio;
        private ICriarHorarioUseCase criarHorarioUseCase;
        private IAtualizarHorarioUseCase atualizarHorarioUseCase;
        private IExcluirHorarioUseCase excluirHorarioUseCase;

        public HorarioController(IHorarioRepositorio horarioRepositorio, ICriarHorarioUseCase criarHorarioUseCase, IAtualizarHorarioUseCase atualizarHorarioUseCase, IExcluirHorarioUseCase excluirHorarioUseCase)
        {
            this.horarioRepositorio = horarioRepositorio;
            this.criarHorarioUseCase = criarHorarioUseCase;
            this.atualizarHorarioUseCase = atualizarHorarioUseCase;
            this.excluirHorarioUseCase = excluirHorarioUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarHorarioRequest request)
        {
            try
            {
                Horario horario = new()
                {
                    diaSemana = request.diaSemana,
                    horarioInicio = request.horarioInicio,
                    horarioFim = request.horarioFim,
                    idTurma = request.idTurma
                };

                await criarHorarioUseCase.CadastrarHorario(horario);
                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarHorarioRequest request)
        {
            try
            {
                Horario horario = new()
                {
                    id = id,
                    diaSemana = request.diaSemana,
                    horarioInicio = request.horarioInicio,
                    horarioFim = request.horarioFim,
                    idTurma = request.idTurma
                };
                await atualizarHorarioUseCase.AtualizarHorario(horario);

                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterHorarios()
        {
            try
            {
                List<Horario> horarios = await horarioRepositorio.ObterTodosOsHorarios();

                List<HorarioResponse> horariosResponse = horarios.Select(h => new HorarioResponse()
                {
                    id = h.id,
                    diaSemana = h.diaSemana,
                    horarioInicio = h.horarioInicio,
                    horarioFim = h.horarioFim,
                    idTurma = h.idTurma
                }).ToList();

                return Ok(horariosResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await excluirHorarioUseCase.ExcluirHorario(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}