using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Adicionar
{
    public interface IAdicionarPessoaUseCase
    {
        Task AdicionarPessoa(Pessoa pessoa);
    }
}