using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Professores.Atualizar
{
    public interface IAtualizarProfessoresUseCase
    {
        Task AtualizarProfessor(Professor professor);
    }
}