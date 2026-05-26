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
        private IHorarioRepositorio horarioRepository;

        public AtualizarHorarioUseCase(IHorarioRepositorio horarioRepository)
        {
            this.horarioRepository = horarioRepository;
        }

        public async Task AlterarHorario(Horario horario)
        {
            await horarioRepository.Alterar(horario);
        }
    }
}