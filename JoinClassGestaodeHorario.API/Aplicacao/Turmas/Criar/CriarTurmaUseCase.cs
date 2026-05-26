using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Criar
{
    public class CriarTurmaCase : ICriarTurmaUseCase
    {
        private ITurmaRepositorio turmaRepositorio;

        public CriarTurmaCase(ITurmaRepositorio turmaRepositorio)
        {
            this.turmaRepositorio = turmaRepositorio;
        }

        public async Task CadastrarTurma(Turma turma)
        {
            await turmaRepositorio.Criar(turma);
        }
    }
}