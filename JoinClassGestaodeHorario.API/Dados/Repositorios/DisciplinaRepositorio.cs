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
            var disciplina = contexto.Disciplinas
                 .FromSql($"Select * From disciplina where id = {id}");
            return await disciplina.FirstOrDefaultAsync();
        }

        public async Task<List<Disciplina>> ObterTodasAsDisciplinas()
        {
            var disciplinas = contexto.Database
                .SqlQuery<Disciplina>($"Select * From disciplina");
            return await disciplinas.ToListAsync();
        }
    }
}