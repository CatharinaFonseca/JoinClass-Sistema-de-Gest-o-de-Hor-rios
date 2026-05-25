using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Excluir
{
    public interface IExcluirTurmaUseCase
    {
        Task ExcluirTurma(int id);
    }
}