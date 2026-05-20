using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IAlunoRepositorio
    {
        Task Adicionar(Aluno aluno);

        Task Alterar(Aluno aluno);

        Task Deletar(Aluno aluno);
        Task<Aluno> ObterAluno(int id);
        Task<List<Aluno>> ObterTodosOsAlunos();
    }
}