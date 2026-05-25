using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar
{
    public class AtualizarHorarioUseCase : IAtualizarHorarioUseCase
    {
        private IHorarioRepositorio horarioRepositorio;

        public AtualizarHorarioUseCase(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
        }

        public async Task AtualizarHorario(Horario horario)
        {
            await horarioRepositorio.Alterar(horario);
        }
    }
}