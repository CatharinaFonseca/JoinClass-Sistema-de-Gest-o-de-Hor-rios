using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Turmas.Atualizar
{
    public interface IAtualizarTurmasUseCase
    {
        Task AtualizarTurma(Turma turma);
    }
}