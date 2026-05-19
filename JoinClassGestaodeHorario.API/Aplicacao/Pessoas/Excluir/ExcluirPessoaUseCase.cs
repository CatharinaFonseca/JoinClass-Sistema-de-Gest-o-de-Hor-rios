using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Excluir
{
    public class ExcluirPessoaUseCase : IExcluirPessoaUseCase
    {
        private IPessoaRepositorio pessoaRepositorio;

        public ExcluirPessoaUseCase(IPessoaRepositorio pessoaRepositorio)
        {
            this.pessoaRepositorio = pessoaRepositorio;
        }

        public async Task ExcluirPessoa(int id)
        {
            Pessoa pessoa = await pessoaRepositorio.ObterPessoa(id);
            await pessoaRepositorio.Deletar(pessoa);
        }
    }
}