using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private ApplicationDbContext contexto;

        public ProfessorRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Professor professor)
        {
            await contexto.Pessoas.AddAsync(professor);
            await contexto.SaveChangesAsync();
        }

        public async Task Alterar(Professor professor)
        {
            contexto.Pessoas.Update(professor);
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Professor professor)
        {
            contexto.Pessoas.Remove(professor);
            await contexto.SaveChangesAsync();
        }

        public async Task<Professor> ObterProfessor(int id)
        {
            var professor = contexto.Professores
                .FromSql($"Select * From professor where id = {id}");
            return await professor.FirstOrDefaultAsync();
        }

        public async Task<List<Professor>> ObterTodosOsProfessores()
        {
            var professores = contexto.Database
                .SqlQuery<Professor>($"Select * From professor");
            return await professores.ToListAsync();
        }
    }
}