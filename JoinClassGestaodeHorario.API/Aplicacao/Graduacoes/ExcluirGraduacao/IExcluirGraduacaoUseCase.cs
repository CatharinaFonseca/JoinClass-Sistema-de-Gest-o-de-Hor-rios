using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacaoUseCase
{
    public interface IExcluirGraduacaoUseCase
    {
        Task ExcluirGraduacao(int id);
    }
}