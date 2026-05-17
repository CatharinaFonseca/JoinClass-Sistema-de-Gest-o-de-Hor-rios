using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Alunos.Adicionar
{
    public interface IAdicionarAlunoUseCase
    {
        Task CadastrarAluno(Aluno aluno);
    }
}