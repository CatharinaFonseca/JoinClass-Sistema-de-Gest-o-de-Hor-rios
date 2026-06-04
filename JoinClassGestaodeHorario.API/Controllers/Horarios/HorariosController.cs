using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Excluir;
using JoinClassGestaodeHorario.API.Controllers.Horarios.Request;
using JoinClassGestaodeHorario.API.Controllers.Horarios.Response;
<<<<<<< HEAD
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers.Horarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
=======
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
>>>>>>> feature/Gabriela
    {
        private IHorarioRepositorio horarioRepositorio;
        private ICriarHorarioUseCase criarHorarioUseCase;
        private IAtualizarHorarioUseCase atualizarHorarioUseCase;
        private IExcluirHorarioUseCase excluirHorarioUseCase;

<<<<<<< HEAD
        public HorariosController(IHorarioRepositorio horarioRepositorio, ICriarHorarioUseCase criarHorarioUseCase, IAtualizarHorarioUseCase atualizarHorarioUseCase, IExcluirHorarioUseCase excluirHorarioUseCase)
=======
        public HorarioController(IHorarioRepositorio horarioRepositorio, ICriarHorarioUseCase criarHorarioUseCase, IAtualizarHorarioUseCase atualizarHorarioUseCase, IExcluirHorarioUseCase excluirHorarioUseCase)
>>>>>>> feature/Gabriela
        {
            this.horarioRepositorio = horarioRepositorio;
            this.criarHorarioUseCase = criarHorarioUseCase;
            this.atualizarHorarioUseCase = atualizarHorarioUseCase;
            this.excluirHorarioUseCase = excluirHorarioUseCase;
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Cadastrar([FromBody] CriarHorarioRequest request)
=======
        public async Task<IActionResult> Criar(CriarHorarioRequest request)
>>>>>>> feature/Gabriela
        {
            try
            {
                Horario horario = new()
                {
<<<<<<< HEAD
                    dia_semana = request.dia_semana,
                    horario_inicio = request.horario_inicio,
                    horario_fim = request.horario_fim
                };
                await criarHorarioUseCase.CadastrarHorario(horario);

=======
                    diaSemana = request.diaSemana,
                    horarioInicio = request.horarioInicio,
                    horarioFim = request.horarioFim,
                    idTurma = request.idTurma
                };

                await criarHorarioUseCase.CadastrarHorario(horario);
>>>>>>> feature/Gabriela
                return Created();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
<<<<<<< HEAD
=======

>>>>>>> feature/Gabriela
        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarHorarioRequest request)
        {
            try
            {
                Horario horario = new()
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
                    idTurma = request.idTurma
>>>>>>> feature/Gabriela
                };
                await atualizarHorarioUseCase.AtualizarHorario(horario);

                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

<<<<<<< HEAD
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
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

=======
>>>>>>> feature/Gabriela
        [HttpGet]
        public async Task<IActionResult> ObterHorarios()
        {
            try
            {
                List<Horario> horarios = await horarioRepositorio.ObterTodosOsHorarios();

                List<HorarioResponse> horariosResponse = horarios.Select(h => new HorarioResponse()
                {
                    id = h.id,
<<<<<<< HEAD
                    dia_semana = h.dia_semana,
                    horario_inicio = h.horario_inicio,
                    horario_fim = h.horario_fim
=======
                    diaSemana = h.diaSemana,
                    horarioInicio = h.horarioInicio,
                    horarioFim = h.horarioFim,
                    idTurma = h.idTurma
>>>>>>> feature/Gabriela
                }).ToList();

                return Ok(horariosResponse);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
<<<<<<< HEAD
=======

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
>>>>>>> feature/Gabriela
    }
}