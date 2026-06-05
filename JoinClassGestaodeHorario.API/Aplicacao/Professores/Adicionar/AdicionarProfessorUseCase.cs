using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Professores.Adicionar
{
    public class AdicionarProfessorUseCase : IAdicionarProfessoresUseCase
    {
        private IProfessorRepositorio professorRepositorio;

        public AdicionarProfessorUseCase(IProfessorRepositorio professorRepositorio)
        {
            this.professorRepositorio = professorRepositorio;
        }

        public async Task CadastrarProfessor(Professor professor)
        {
            //Impedir professor sem nome 
            if (string.IsNullOrWhiteSpace(professor.nome))
            {
                throw new Exception("Nome do professor é obrigatório.");
            }

            await professorRepositorio.Adicionar(professor);
        }
    }
}