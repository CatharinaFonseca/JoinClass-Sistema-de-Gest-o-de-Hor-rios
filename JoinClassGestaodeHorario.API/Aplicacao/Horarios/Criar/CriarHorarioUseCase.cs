using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using JoinClassGestaodeHorario.API.Services;
using JoinClassGestaodeHorario.API.Services;

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Criar
{
    public class CriarHorarioUseCase : ICriarHorarioUseCase
    {
        private IHorarioRepositorio horarioRepositorio;
        private GerarHorariosService gerarHorariosService;

        public CriarHorarioUseCase(IHorarioRepositorio horarioRepositorio, GerarHorariosService gerarHorariosService)
        {
            this.horarioRepositorio = horarioRepositorio;
            this.gerarHorariosService = gerarHorariosService;
        }

        public async Task CadastrarHorario(Horario horario)
        {

            gerarHorariosService.ValidarHorario(horario);

            await horarioRepositorio.Criar(horario);
        }
    }
}