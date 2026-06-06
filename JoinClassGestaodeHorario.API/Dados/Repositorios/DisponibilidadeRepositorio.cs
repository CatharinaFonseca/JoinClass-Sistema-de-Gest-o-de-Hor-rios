using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class DisponibilidadeRepositorio : IDisponibilidadeResitorio
    {
        private ApplicationDbContext contexto;

        public DisponibilidadeRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Alterar(Disponibilidade disponibilidade)
        {
            contexto.Disponibilidades.Update(disponibilidade);
            await contexto.SaveChangesAsync();
        }

        public async Task Criar(Disponibilidade disponibilidade)
        {
            await contexto.Disponibilidades.AddAsync(disponibilidade);
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Disponibilidade disponibilidade)
        {
            contexto.Disponibilidades.Remove(disponibilidade);
            await contexto.SaveChangesAsync();
        }

        public async Task<Disponibilidade> ObterDisponibilidade(int id)
        {
            return await contexto.Disponibilidades
               .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Disponibilidade>> ObterTodasAsDisponibilidades()
        {
            return await contexto.Disponibilidades.ToListAsync();
        }
    }
}