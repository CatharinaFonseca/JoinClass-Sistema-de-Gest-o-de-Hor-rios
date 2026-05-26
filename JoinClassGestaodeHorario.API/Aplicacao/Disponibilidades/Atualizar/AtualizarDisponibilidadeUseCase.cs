using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Atualizar
{
    public class AtualizarDisponibilidadeUseCase : IAtualizarDisponibilidadeUseCase
    {
        private IDisponibilidadeResitorio disponibilidadeResitorio;

        public AtualizarDisponibilidadeUseCase(IDisponibilidadeResitorio disponibilidadeResitorio)
        {
            this.disponibilidadeResitorio = disponibilidadeResitorio;
        }

        public async Task AtualizarDisponibilidade(Disponibilidade disponibilidade)
        {
            await disponibilidadeResitorio.Alterar(disponibilidade);
        }
    }
}