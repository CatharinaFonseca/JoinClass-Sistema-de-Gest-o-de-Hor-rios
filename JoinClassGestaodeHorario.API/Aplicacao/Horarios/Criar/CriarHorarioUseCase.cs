using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
<<<<<<< HEAD
=======
using JoinClassGestaodeHorario.API.Services;
>>>>>>> feature/Gabriela

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Criar
{
    public class CriarHorarioUseCase : ICriarHorarioUseCase
    {
        private IHorarioRepositorio horarioRepositorio;
<<<<<<< HEAD

        public CriarHorarioUseCase(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
=======
        private GerarHorariosService gerarHorariosService;

        public CriarHorarioUseCase(IHorarioRepositorio horarioRepositorio, GerarHorariosService gerarHorariosService)
        {
            this.horarioRepositorio = horarioRepositorio;
            this.gerarHorariosService = gerarHorariosService;
>>>>>>> feature/Gabriela
        }

        public async Task CadastrarHorario(Horario horario)
        {
<<<<<<< HEAD
            await horarioRepositorio.Adicionar(horario);
=======
            gerarHorariosService.ValidarHorario(horario);

            await horarioRepositorio.Criar(horario);
>>>>>>> feature/Gabriela
        }
    }
}