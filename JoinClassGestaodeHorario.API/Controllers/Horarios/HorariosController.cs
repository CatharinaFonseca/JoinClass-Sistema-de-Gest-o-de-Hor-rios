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
using JoinClassGestaodeHorario.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Controllers.Horarios
{
    [ApiController]
    [Route("api/horarios")]
    public class HorarioController : ControllerBase
    {
        private IHorarioRepositorio horarioRepositorio;
        private ICriarHorarioUseCase criarHorarioUseCase;
        private IAtualizarHorarioUseCase atualizarHorarioUseCase;
        private IExcluirHorarioUseCase excluirHorarioUseCase;
        private readonly ApplicationDbContext _contexto;
        private readonly GerarHorariosService _service;

        public HorarioController(IHorarioRepositorio horarioRepositorio, ICriarHorarioUseCase criarHorarioUseCase, IAtualizarHorarioUseCase atualizarHorarioUseCase, IExcluirHorarioUseCase excluirHorarioUseCase, ApplicationDbContext contexto, GerarHorariosService service)
        {
            this.horarioRepositorio = horarioRepositorio;
            this.criarHorarioUseCase = criarHorarioUseCase;
            this.atualizarHorarioUseCase = atualizarHorarioUseCase;
            this.excluirHorarioUseCase = excluirHorarioUseCase;
            this._contexto = contexto;
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CriarHorarioRequest request)
        {
            try
            {
                Horario horario = new()
                {
                    dia_semana = request.dia_semana,
                    horario_inicio = request.horario_inicio,
                    horario_fim = request.horario_fim,
                    id_turma = request.id_turma
                };

                _service.ValidarHorario(horario);

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
                    dia_semana = request.dia_semana,
                    horario_inicio = request.horario_inicio,
                    horario_fim = request.horario_fim,
                    id_turma = request.id_turma
                };
                await atualizarHorarioUseCase.AtualizarHorario(horario);

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
                await excluirHorarioUseCase.ExcluirHorario(id);
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
            var horarios = await _contexto.Horarios
     .Include(h => h.Turma)
         .ThenInclude(t => t.Professor)
     .Include(h => h.Turma)
         .ThenInclude(t => t.Disciplina)
     .ToListAsync();

            var response = horarios.Select(h => new HorarioResponse
            {
                id = h.id,
                dia_semana = h.dia_semana,
                horario_inicio = h.horario_inicio,
                horario_fim = h.horario_fim,

                professor = h.Turma.Professor.nome,
                disciplina = h.Turma.Disciplina.nome
            });

            return Ok(response);
        }
    }
}