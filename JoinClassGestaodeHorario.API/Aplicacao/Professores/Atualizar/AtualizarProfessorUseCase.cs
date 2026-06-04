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
            //Impedir professor sem nome 
            if (string.IsNullOrWhiteSpace(professor.nome))
            {
                throw new Exception("Nome do professor é obrigatório.");
            }
            //Professor precisa informar quando pode dar aula 
            if (!professor.Disponibilidades.Any())
            {
                throw new Exception(
                    "Professor deve possuir disponibilidade cadastrada.");
            }
            
            await professorRepositorio.Alterar(professor);
        }
    }
}