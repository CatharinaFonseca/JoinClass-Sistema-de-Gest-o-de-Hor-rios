using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.CriarGraduacao
{
    public interface ICriarGraduacaoUseCase
    {
        Task CadastrarGraduacao(Graduacao graduacao);
    }
}