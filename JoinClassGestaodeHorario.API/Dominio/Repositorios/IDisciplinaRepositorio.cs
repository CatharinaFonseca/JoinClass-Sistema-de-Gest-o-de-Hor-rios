using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IDisciplinaRepositorio
    {
        Task Adicionar(Disciplina disciplina);

        Task Alterar(Disciplina disciplina);

        Task Deletar(Disciplina disciplina);
        Task<Disciplina> ObterDisciplina(int id);
        Task<List<Disciplina>> ObterTodasAsDisciplinas();
    }
}