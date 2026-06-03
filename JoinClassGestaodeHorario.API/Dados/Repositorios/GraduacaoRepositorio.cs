using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class GraduacaoRepositorio : IGraduacaoRepositorio
    {
        private ApplicationDbContext contexto;

        public GraduacaoRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Alterar(Graduacao graduacao)
        {
            //Prepara Update
            contexto.Graduacoes.Update(graduacao);
            //Commit Update
            await contexto.SaveChangesAsync();
        }

        public async Task Criar(Graduacao graduacao)
        {
            //Prepara Insert
            await contexto.Graduacoes.AddAsync(graduacao);
            //Commit Insert
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Graduacao graduacao)
        {
            //Prepara Delete
            contexto.Graduacoes.Remove(graduacao);
            //Commit Delete
            await contexto.SaveChangesAsync();
        }

        public async Task<Graduacao> ObterGraduacao(int id)
        {
            var graduacao = contexto.Graduacoes
                .FromSqlInterpolated($"Select * From graduacao where id = {id}");
            return await graduacao.FirstOrDefaultAsync();
        }

        public async Task<List<Graduacao>> ObterTodasAsGraduacoes()
        {
            return await contexto.Graduacoes
                .ToListAsync();
        }
    }
}