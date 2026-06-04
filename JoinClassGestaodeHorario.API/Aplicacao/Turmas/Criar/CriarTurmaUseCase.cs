using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Criar
{
    public class CriarTurmaUseCase : ICriarTurmaUseCase
    {
        private ITurmaRepositorio turmaRepositorio;

        public CriarTurmaUseCase(ITurmaRepositorio turmaRepositorio)
        {
            this.turmaRepositorio = turmaRepositorio;
        }

        public async Task CadastrarTurma(Turma turma)
        {
            if (turma.idProfessor <= 0)
            {
                throw new Exception("Professor é obrigatório.");
            }

            await turmaRepositorio.Criar(turma);
        }
    }
}