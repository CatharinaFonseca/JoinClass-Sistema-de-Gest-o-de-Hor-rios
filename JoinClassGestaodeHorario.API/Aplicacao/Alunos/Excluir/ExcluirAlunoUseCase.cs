using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Alunos.Excluir
{
    public class ExcluirAlunoUseCase : IExcluirAlunoUseCase
    {
        private IAlunoRepositorio alunoRepositorio;

        public ExcluirAlunoUseCase(IAlunoRepositorio alunoRepositorio)
        {
            this.alunoRepositorio = alunoRepositorio;
        }

        public async Task ExcluirAluno(int id)
        {
            //Busca Aluno
            Aluno aluno = await alunoRepositorio.ObterAluno(id);
            //Deleta Aluno
            await alunoRepositorio.Deletar(aluno);
        }
    }
}