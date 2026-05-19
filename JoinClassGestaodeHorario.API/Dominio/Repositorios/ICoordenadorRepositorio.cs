using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface ICoordenadorRepositorio
    {
        Task Adicionar(Coordenador coordenador);

        Task Alterar(Coordenador coordenador);

        Task Deletar(Coordenador coordenador);
        Task<Coordenador> ObterCoordenador(int id);
        Task<List<Coordenador>> ObterTodosOsCoordenadores();
    }
}