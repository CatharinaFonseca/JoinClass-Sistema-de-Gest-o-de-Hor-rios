using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Atualizar
{
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase
    {
        private IPessoaRepositorio pessoaRepositorio;

        public AtualizarPessoaUseCase(IPessoaRepositorio pessoaRepositorio)
        {
            this.pessoaRepositorio = pessoaRepositorio;
        }

        public async Task AtualizarPessoa(Pessoa pessoa)
        {
            await pessoaRepositorio.Alterar(pessoa);
        }
    }
}