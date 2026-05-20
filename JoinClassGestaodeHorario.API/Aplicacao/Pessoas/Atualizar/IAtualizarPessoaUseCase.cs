using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Atualizar
{
    public interface IAtualizarPessoaUseCase
    {
        Task AtualizarPessoa(Pessoa pessoa);
    }
}