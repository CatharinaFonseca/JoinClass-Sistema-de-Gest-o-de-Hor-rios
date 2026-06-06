using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class DisciplinaRepositorio : IDisciplinaRepositorio
    {
        private ApplicationDbContext contexto;

        public DisciplinaRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Disciplina disciplina)
        {
            await contexto.Disciplinas.AddAsync(disciplina);
            await contexto.SaveChangesAsync();
        }

        public async Task Alterar(Disciplina disciplina)
        {
            contexto.Disciplinas.Update(disciplina);
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Disciplina disciplina)
        {
            contexto.Disciplinas.Remove(disciplina);
            await contexto.SaveChangesAsync();
        }

        public async Task<Disciplina> ObterDisciplina(int id)
        {
            return await contexto.Disciplinas
               .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Disciplina>> ObterTodasAsDisciplinas()
        {
            return await contexto.Disciplinas.ToListAsync();
        }
    }
}