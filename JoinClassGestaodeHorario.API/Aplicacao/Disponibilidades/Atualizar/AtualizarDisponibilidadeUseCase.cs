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
            //Garantir qu o professor informou o dia disponivel 
            if (string.IsNullOrWhiteSpace(disponibilidade.diaSemana))
            {
                throw new Exception("Dia da semana é obrigatório.");
            }
            //Evitar disponibilidade inválida 
            if (string.Compare(
                disponibilidade.horarioFim,
                disponibilidade.horarioInicio) <= 0)
            {
                throw new Exception("Horário final deve ser maior que horário inicial.");
            }

            await disponibilidadeResitorio.Alterar(disponibilidade);
        }
    }
}