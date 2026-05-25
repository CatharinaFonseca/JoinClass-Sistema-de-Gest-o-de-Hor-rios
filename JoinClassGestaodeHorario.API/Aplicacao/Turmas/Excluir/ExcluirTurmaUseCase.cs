using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Excluir
{
    public class ExcluirTurmaUseCase : IExcluirTurmaUseCase
    {
        private ITurmaRepositorio turmaRepositorio;

        public ExcluirTurmaUseCase(ITurmaRepositorio turmaRepositorio)
        {
            this.turmaRepositorio = turmaRepositorio;
        }

        public async Task ExcluirTurma(int id)
        {
            Turma turma = await turmaRepositorio.ObterTurma(id);
            await turmaRepositorio.Deletar(turma);
        }
    }
}