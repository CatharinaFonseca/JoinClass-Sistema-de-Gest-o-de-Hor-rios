using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private ApplicationDbContext contexto;

        public TurmaRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

<<<<<<< HEAD
        public async Task Adicionar(Turma turma)
        {
            await contexto.Turmas.AddAsync(turma);
            await contexto.SaveChangesAsync();
        }

=======
>>>>>>> feature/Gabriela
        public async Task Alterar(Turma turma)
        {
            contexto.Turmas.Update(turma);
            await contexto.SaveChangesAsync();
        }

<<<<<<< HEAD
        public Task Criar(Turma turma)
        {
            throw new NotImplementedException();
=======
        public async Task Criar(Turma turma)
        {
            await contexto.Turmas.AddAsync(turma);
            await contexto.SaveChangesAsync();
>>>>>>> feature/Gabriela
        }

        public async Task Deletar(Turma turma)
        {
            contexto.Turmas.Remove(turma);
            await contexto.SaveChangesAsync();
        }

        public async Task<List<Turma>> ObterTodasAsTurmas()
        {
            var turmas = contexto.Turmas
<<<<<<< HEAD
                 .FromSql($"Select * From turma");
=======
                 .FromSql($"Select * From turmas");
>>>>>>> feature/Gabriela
            return await turmas.ToListAsync();
        }

        public async Task<Turma> ObterTurma(int id)
        {
            var turma = contexto.Database
<<<<<<< HEAD
                .SqlQuery<Turma>($"Select * From turma where id = {id}");
=======
                 .SqlQuery<Turma>($"Select * From turmas where id = {id}");
>>>>>>> feature/Gabriela
            return await turma.FirstOrDefaultAsync();
        }
    }
}