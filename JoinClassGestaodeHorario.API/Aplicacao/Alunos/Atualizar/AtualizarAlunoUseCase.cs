using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Alunos.Atualizar
{
    public class AtualizarAlunoUseCase : IAtualizarAlunoUseCase
    {
        private IAlunoRepositorio alunoRepositorio;

        public AtualizarAlunoUseCase(IAlunoRepositorio alunoRepositorio)
        {
            this.alunoRepositorio = alunoRepositorio;
        }

        public async Task AtualizarAluno(Aluno aluno)
        {
            //Impede cadastro incompleto
            if (string.IsNullOrWhiteSpace(aluno.nome))
            {
                throw new Exception("Nome do aluno é obrigatório.");
            }
            
            await alunoRepositorio.Alterar(aluno);
        }
    }
}