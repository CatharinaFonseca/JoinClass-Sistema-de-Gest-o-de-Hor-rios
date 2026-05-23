using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Atualizar
{
    public interface IAtualizarDisciplinaUseCase
    {
        Task AtualizarDisciplina(Disciplina disciplina);
    }
}