using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IDisponibilidadeResitorio
    {
        Task Criar(Disponibilidade disponibilidade);

        Task Alterar(Disponibilidade disponibilidade);

        Task Deletar(Disponibilidade disponibilidade);
        Task<Disponibilidade> ObterDisponibilidade(int id);
        Task<List<Disponibilidade>> ObterTodasAsDisponibilidades();
    }
}