using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Criar
{
    public interface ICriarDisciplinaUseCase
    {
        Task CadastrarDisciplina(Disciplina disciplina);
    }
}