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
        private readonly ApplicationDbContext contexto;

        public HorarioController(ApplicationDbContext contexto)
        {
            contexto = contexto;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarHorarioRequest request)
        {
            var turma = await contexto.Turmas.FindAsync(request.IdTurma);

            if (turma == null)
                return NotFound("Turma não encontrada");

            var horario = new Horario
            {
                DiaSemana = request.DiaSemana,
                HorarioInicio = request.HorarioInicio,
                HorarioFim = request.HorarioFim,
                IdTurma = request.IdTurma
            };

            contexto.Horarios.Add(horario);
            await contexto.SaveChangesAsync();

            return Ok(horario);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var horarios = await contexto.Horarios
                .Include(h => h.Turma)
                .ToListAsync();

            return Ok(horarios);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var horario = await contexto.Horarios.FindAsync(id);

            if (horario == null)
                return NotFound();

            contexto.Horarios.Remove(horario);
            await contexto.SaveChangesAsync();

            return Ok();
        }
    }
}