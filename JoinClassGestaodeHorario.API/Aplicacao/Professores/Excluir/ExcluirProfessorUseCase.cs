using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Professores.Excluir
{
    public class ExcluirProfessorUseCase : IExcluirProfessorUseCase
    {
        private IProfessorRepositorio professorRepositorio;

        public ExcluirProfessorUseCase(IProfessorRepositorio professorRepositorio)
        {
            this.professorRepositorio = professorRepositorio;
        }

        public async Task ExcluirProfessor(int id)
        {
            Professor professor = await professorRepositorio.ObterProfessor(id);
            await professorRepositorio.Deletar(professor);
        }
    }
}