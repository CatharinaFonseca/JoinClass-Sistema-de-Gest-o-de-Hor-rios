using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Atualizar
{
<<<<<<< HEAD
    public class AtualizarTurmaUseCase : IAtualizarTurmasUseCase
=======
    public class AtualizarTurmaUseCase : IAtualizarTurmaUseCase
>>>>>>> feature/Gabriela
    {
        private ITurmaRepositorio turmaRepositorio;

        public AtualizarTurmaUseCase(ITurmaRepositorio turmaRepositorio)
        {
            this.turmaRepositorio = turmaRepositorio;
        }

        public async Task AtualizarTurma(Turma turma)
        {
<<<<<<< HEAD
=======
            if (turma.idProfessor <= 0)
            {
                throw new Exception("Professor é obrigatório.");
            }

>>>>>>> feature/Gabriela
            await turmaRepositorio.Alterar(turma);
        }
    }
}