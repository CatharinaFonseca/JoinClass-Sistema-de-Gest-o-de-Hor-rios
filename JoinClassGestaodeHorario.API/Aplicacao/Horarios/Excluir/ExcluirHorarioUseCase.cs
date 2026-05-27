using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Excluir
{
    public class ExcluirHorarioUseCase : IExcluirHorarioUseCase
    {
        private IHorarioRepositorio horarioRepositorio;

        public ExcluirHorarioUseCase(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
        }

        public async Task ExcluirHorario(int id)
        {
            Horario horario = await horarioRepositorio.ObterHorario(id);
            await horarioRepositorio.Deletar(horario);
        }
    }
}