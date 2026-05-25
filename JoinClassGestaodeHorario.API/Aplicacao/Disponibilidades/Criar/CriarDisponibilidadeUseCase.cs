using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Criar
{
    public class CriarDisponibilidadeUseCase : ICriarDisponibilidadeUseCase
    {
        private IDisponibilidadeResitorio disponibilidadeResitorio;

        public CriarDisponibilidadeUseCase(IDisponibilidadeResitorio disponibilidadeResitorio)
        {
            this.disponibilidadeResitorio = disponibilidadeResitorio;
        }

        public async Task CadastrarDisponibilidade(Disponibilidade disponibilidade)
        {
            await disponibilidadeResitorio.Criar(disponibilidade);
        }
    }
}