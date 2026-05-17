using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private ApplicationDbContext contexto;

        public AlunoRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Alterar(Aluno aluno)
        {
            //Prepara Update
            contexto.Alunos.Update(aluno);
            //Commit Update
            await contexto.SaveChangesAsync();
        }

        public async Task Adicionar(Aluno aluno)
        {
            //Prepara Insert
            await contexto.Alunos.AddAsync(aluno);
            //Commit Insert
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Aluno aluno)
        {
            //Prepara Delete
            contexto.Alunos.Remove(aluno);
            //Commit Delete
            await contexto.SaveChangesAsync();
        }

        public async Task<Aluno> ObterAluno(int id)
        {
            var aluno = contexto.Alunos
                .FromSql($"Select * From aluno where id = {id}");
            return await aluno.FirstOrDefaultAsync();
        }

        public async Task<List<Aluno>> ObterTodosOsAlunos()
        {
            var alunos = contexto.Alunos
                .FromSql($"Select * From aluno");
            return await alunos.ToListAsync();
        }
    }
}