using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface ITurmaRepositorio
    {
        Task Adicionar(Turma turma);
        Task Alterar(Turma turma);
        Task Deletar(Turma turma);
        Task<Turma> ObterTurma(int id);
        Task<List<Turma>> ObterTodasAsTurmas();
    }
}