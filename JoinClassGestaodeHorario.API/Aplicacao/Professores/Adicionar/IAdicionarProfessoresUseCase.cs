using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Professores.Adicionar
{
    public interface IAdicionarProfessoresUseCase
    {
        Task CadastrarProfessor(Professor professor);
    }
}