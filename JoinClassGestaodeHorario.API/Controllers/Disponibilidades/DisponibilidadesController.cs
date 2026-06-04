using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Disponibilidades.Request;
using JoinClassGestaodeHorario.API.Controllers.Disponibilidades.Response;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Disponibilidades
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisponibilidadesController : ControllerBase
    {
        private IDisponibilidadeResitorio disponibilidadeRepositorio;
        private ICriarDisponibilidadeUseCase criarDisponibilidadeUseCase;
        private IAtualizarDisponibilidadeUseCase atualizarDisponibilidadeUseCase;
        private IExcluirDisponibilidadeUseCase excluirDisponibilidadeUseCase;

        public DisponibilidadesController(IDisponibilidadeResitorio disponibilidadeRepositorio, ICriarDisponibilidadeUseCase criarDisponibilidadeUseCase, IAtualizarDisponibilidadeUseCase atualizarDisponibilidadeUseCase, IExcluirDisponibilidadeUseCase excluirDisponibilidadeUseCase)
        {
            this.disponibilidadeRepositorio = disponibilidadeRepositorio;
            this.criarDisponibilidadeUseCase = criarDisponibilidadeUseCase;
            this.atualizarDisponibilidadeUseCase = atualizarDisponibilidadeUseCase;
            this.excluirDisponibilidadeUseCase = excluirDisponibilidadeUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CriarDisponibilidadeRequest request)
        {
            try
            {
                Disponibilidade disponibilidade = new()
                {
<<<<<<< HEAD
                    dia_semana = request.dia_semana,
                    horario_inicio = request.horario_inicio,
                    horario_fim = request.horario_fim
=======
                    diaSemana = request.diaSemana,
                    horarioInicio = request.horarioInicio,
                    horarioFim = request.horarioFim,
                    idProfessor = request.idProfessor
>>>>>>> feature/Gabriela
                };
                await criarDisponibilidadeUseCase.CadastrarDisponibilidade(disponibilidade);

                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarDisponibilidadeRequest request)
        {
            try
            {
                Disponibilidade disponibilidade = new()
                {
<<<<<<< HEAD
                    dia_semana = request.dia_semana,
                    horario_inicio = request.horario_inicio,
                    horario_fim = request.horario_fim
=======
                    id = id,
                    diaSemana = request.diaSemana,
                    horarioInicio = request.horarioInicio,
                    horarioFim = request.horarioFim,
                    idProfessor = request.idProfessor
>>>>>>> feature/Gabriela
                };
                await atualizarDisponibilidadeUseCase.AtualizarDisponibilidade(disponibilidade);

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
                await excluirDisponibilidadeUseCase.ExcluirDisponibilidade(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterDisponibilidades()
        {
            try
            {
                List<Disponibilidade> disponibilidades = await disponibilidadeRepositorio.ObterTodasAsDisponibilidades();

                List<DisponibilidadeResponse> disponibilidadesResponse = disponibilidades.Select(d => new DisponibilidadeResponse()
                {
                    id = d.id,
<<<<<<< HEAD
                    dia_semana = d.dia_semana,
                    horario_inicio = d.horario_inicio,
                    horario_fim = d.horario_fim
=======
                    diaSemana = d.diaSemana,
                    horarioInicio = d.horarioInicio,
                    horarioFim = d.horarioFim,
                    idProfessor = d.idProfessor
>>>>>>> feature/Gabriela
                }).ToList();

                return Ok(disponibilidadesResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}