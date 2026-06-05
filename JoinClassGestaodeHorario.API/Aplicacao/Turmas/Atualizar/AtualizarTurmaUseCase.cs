using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Atualizar
{
    public class AtualizarTurmaUseCase : IAtualizarTurmaUseCase
    {

        private ITurmaRepositorio turmaRepositorio;

        public AtualizarTurmaUseCase(ITurmaRepositorio turmaRepositorio)
        {
            this.turmaRepositorio = turmaRepositorio;
        }

        public async Task AtualizarTurma(Turma turma)
        {
            if (turma.id_professor == 0)
            {
                throw new Exception("Professor é obrigatório.");
            }
            await turmaRepositorio.Alterar(turma);
        }
    }
}