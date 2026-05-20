using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Alunos.Atualizar
{
    public interface IAtualizarAlunoUseCase
    {
        Task AtualizarAluno(Aluno aluno);
    }
}