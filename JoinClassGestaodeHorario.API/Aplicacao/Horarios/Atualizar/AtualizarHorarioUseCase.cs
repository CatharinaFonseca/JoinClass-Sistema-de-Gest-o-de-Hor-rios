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

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar
{
    public class AtualizarHorarioUseCase : IAtualizarHorarioUseCase
    {
<<<<<<< HEAD
        private IHorarioRepositorio horarioRepositorio;

        public AtualizarHorarioUseCase(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
=======
        private IHorarioRepositorio horarioRepository;
        private GerarHorariosService gerarHorariosService;

        public AtualizarHorarioUseCase(IHorarioRepositorio horarioRepository, GerarHorariosService gerarHorariosService)
        {
            this.horarioRepository = horarioRepository;
            this.gerarHorariosService = gerarHorariosService;
>>>>>>> feature/Gabriela
        }

        public async Task AtualizarHorario(Horario horario)
        {
<<<<<<< HEAD
            await horarioRepositorio.Alterar(horario);
=======
            gerarHorariosService.ValidarHorario(horario);

            await horarioRepository.Alterar(horario);
>>>>>>> feature/Gabriela
        }
    }
}