using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Excluir
{
    public interface IExcluirDisciplinaUseCase
    {
        Task ExcluirDisciplina(int id);
    }
}