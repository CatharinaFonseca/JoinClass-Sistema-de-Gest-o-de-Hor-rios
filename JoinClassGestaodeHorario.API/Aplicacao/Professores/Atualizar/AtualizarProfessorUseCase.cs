using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Professores.Atualizar
{
    public class AtualizarProfessorUseCase : IAtualizarProfessoresUseCase
    {
        private IProfessorRepositorio professorRepositorio;

        public AtualizarProfessorUseCase(IProfessorRepositorio professorRepositorio)
        {
            this.professorRepositorio = professorRepositorio;
        }

        public async Task AtualizarProfessor(Professor professor)
        {
            await professorRepositorio.Alterar(professor);
        }
    }
}