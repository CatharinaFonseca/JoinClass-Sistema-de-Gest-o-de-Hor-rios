using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IPessoaRepositorio
    {
        Task Adicionar(Pessoa pessoa);

        Task Alterar(Pessoa pessoa);

        Task Deletar(Pessoa pessoa);
        Task<Pessoa> ObterPessoa(int id);
        Task<List<Pessoa>> ObterTodasAsPessoas();
    }
}