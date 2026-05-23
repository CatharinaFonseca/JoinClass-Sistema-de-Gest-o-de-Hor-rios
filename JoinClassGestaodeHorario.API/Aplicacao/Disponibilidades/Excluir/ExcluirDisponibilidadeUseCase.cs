using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Excluir
{
    public class ExcluirDisponibilidadeUseCase : IExcluirDisponibilidadeUseCase
    {
        private IDisponibilidadeResitorio disponibilidadeResitorio;

        public ExcluirDisponibilidadeUseCase(IDisponibilidadeResitorio disponibilidadeResitorio)
        {
            this.disponibilidadeResitorio = disponibilidadeResitorio;
        }

        public async Task ExcluirDisponibilidade(int id)
        {
            Disponibilidade disponibilidade = await disponibilidadeResitorio.ObterDisponibilidade(id);
            await disponibilidadeResitorio.Deletar(disponibilidade);
        }
    }
}