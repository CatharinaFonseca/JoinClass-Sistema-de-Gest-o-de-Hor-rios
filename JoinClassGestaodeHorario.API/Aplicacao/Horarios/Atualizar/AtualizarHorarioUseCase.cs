using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using JoinClassGestaodeHorario.API.Services;
using JoinClassGestaodeHorario.API.Services;

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar
{
    public class AtualizarHorarioUseCase : IAtualizarHorarioUseCase
    {
        private IHorarioRepositorio horarioRepository;
        private GerarHorariosService gerarHorariosService;

        public AtualizarHorarioUseCase(IHorarioRepositorio horarioRepository, GerarHorariosService gerarHorariosService)
        {
            this.horarioRepository = horarioRepository;
            this.gerarHorariosService = gerarHorariosService;
        }

        public async Task AtualizarHorario(Horario horario)
        {
            gerarHorariosService.ValidarHorario(horario);

            await horarioRepository.Alterar(horario);
        }
    }
}