using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class CoordenadorRepositorio : ICoordenadorRepositorio
    {
        private ApplicationDbContext contexto;

        public CoordenadorRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Coordenador coordenador)
        {
            await contexto.Pessoas.AddAsync(coordenador);
            await contexto.SaveChangesAsync();
        }

        public async Task Alterar(Coordenador coordenador)
        {
            contexto.Pessoas.Update(coordenador);
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Coordenador coordenador)
        {
            contexto.Pessoas.Remove(coordenador);
            await contexto.SaveChangesAsync();
        }

        public async Task<Coordenador> ObterCoordenador(int id)
        {
            var coordenador = contexto.Coordenadores
                .FromSql($"Select * From coordenador where id = {id}");
            return await coordenador.FirstOrDefaultAsync();
        }

        public async Task<List<Coordenador>> ObterTodosOsCoordenadores()
        {
            var coordenadores = contexto.Coordenadores
                .FromSql($"Select * From coordenador");
            return await coordenadores.ToListAsync();
        }
    }
}