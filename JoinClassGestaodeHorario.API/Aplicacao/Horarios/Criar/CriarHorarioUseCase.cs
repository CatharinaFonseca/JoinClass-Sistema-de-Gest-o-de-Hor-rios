using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Criar
{
    public class CriarHorarioUseCase : ICriarHorarioUseCase
    {
        private IHorarioRepositorio horarioRepositorio;

        public CriarHorarioUseCase(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
        }

        public async Task CadastrarHorario(Horario horario)
        {
            await horarioRepositorio.Adicionar(horario);
        }
    }
}