using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private ApplicationDbContext contexto;

        public PessoaRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            await contexto.Pessoas.AddAsync(pessoa);
            await contexto.SaveChangesAsync();
        }

        public async Task Alterar(Pessoa pessoa)
        {
            contexto.Pessoas.Update(pessoa);
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Pessoa pessoa)
        {
            contexto.Pessoas.Remove(pessoa);
            await contexto.SaveChangesAsync();
        }

        public async Task<Pessoa> ObterPessoa(int id)
        {
            var pessoa = contexto.Pessoas
                .FromSql($"Select * From pessoa where id = {id}");
            return await pessoa.FirstOrDefaultAsync();
        }

        public async Task<List<Pessoa>> ObterTodasAsPessoas()
        {
            var pessoas = contexto.Database
                .SqlQuery<Pessoa>($"Select * From pessoa");
            return await pessoas.ToListAsync();
        }
    }
}