using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Adicionar
{
    public class AdicionarPessoaUseCase : IAdicionarPessoaUseCase
    {
        private IPessoaRepositorio pessoaRepositorio;

        public AdicionarPessoaUseCase(IPessoaRepositorio pessoaRepositorio)
        {
            this.pessoaRepositorio = pessoaRepositorio;
        }

        public async Task AdicionarPessoa(Pessoa pessoa)
        {
            await pessoaRepositorio.Adicionar(pessoa);
        }
    }
}