using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Alunos.Adicionar
{
    public class AdicionarAlunoUseCase : IAdicionarAlunoUseCase
    {
        private IAlunoRepositorio alunoRepositorio;

        public AdicionarAlunoUseCase(IAlunoRepositorio alunoRepositorio)
        {
            this.alunoRepositorio = alunoRepositorio;
        }

        public async Task CadastrarAluno(Aluno aluno)
        {
            //Impede cadastro incompleto
            if (string.IsNullOrWhiteSpace(aluno.nome))
            {
                throw new Exception("Nome do aluno é obrigatório.");
            }

            await alunoRepositorio.Adicionar(aluno);
        }
    }
}