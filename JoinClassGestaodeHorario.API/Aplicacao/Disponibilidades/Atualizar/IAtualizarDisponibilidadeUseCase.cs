using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Atualizar
{
    public interface IAtualizarDisponibilidadeUseCase
    {
        Task AtualizarDisponibilidade(Disponibilidade disponibilidade);
    }
}