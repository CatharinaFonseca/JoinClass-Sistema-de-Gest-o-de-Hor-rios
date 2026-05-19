using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IProfessorRepositorio
    {
        Task Adicionar(Professor professor);

        Task Alterar(Professor professor);

        Task Deletar(Professor professor);
        Task<Professor> ObterProfessor(int id);
        Task<List<Professor>> ObterTodosOsProfessores();
    }
}