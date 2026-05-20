using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacao
{
    public interface IExcluirGraduacao
    {
        Task ExcluirGraduacao(int id);
    }
}