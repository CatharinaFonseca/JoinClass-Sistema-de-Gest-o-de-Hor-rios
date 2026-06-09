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

        [HttpPost("gerar-automatico/{idTurma}")]
        public async Task<IActionResult> GerarAutomatico([FromRoute] int idTurma, [FromBody] List<int> idsDisciplinas)
        {
            try
            {
                if (idsDisciplinas == null || !idsDisciplinas.Any())
                {
                    return BadRequest("Você precisa enviar pelo menos o ID de uma disciplina.");
                }

                var horariosCriados = await _service.GerarHorarioAutomatico(idTurma, idsDisciplinas);

                return Ok(new { mensagem = "Horários gerados com sucesso!", quantidade = horariosCriados.Count });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
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
            try
            {
                // Buscamos os dados diretamente da tabela de horários.
                // Se o EF não encontrar o objeto mapeado, ele preenche com o texto alternativo sem zerar a lista.
                var response = await _contexto.Horarios
                    .Select(h => new HorarioResponse
                    {
                        id = h.id,
                        id_turma = h.id_turma,
                        dia_semana = h.dia_semana,
                        horario_inicio = h.horario_inicio,
                        horario_fim = h.horario_fim,

                        // Buscando diretamente do relacionamento do Horário com o Professor/Pessoa
                        professor = h.id_professor != 0 && _contexto.Pessoas.Any(p => p.id == h.id_professor)
                                    ? _contexto.Pessoas.Where(p => p.id == h.id_professor).Select(p => p.nome).FirstOrDefault()
                                    : "Sem Professor",

                        // Buscando diretamente do relacionamento do Horário com a Disciplina
                        disciplina = h.id_disciplina != 0 && _contexto.Disciplinas.Any(d => d.id == h.id_disciplina)
                                     ? _contexto.Disciplinas.Where(d => d.id == h.id_disciplina).Select(d => d.nome).FirstOrDefault()
                                     : "Sem Disciplina"
                    })
                    .ToListAsync();

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao listar horários", detalhe = ex.Message });
            }
        }
    }
}