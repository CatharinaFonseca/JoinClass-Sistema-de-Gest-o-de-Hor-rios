using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IHorarioRepositorio
    {
<<<<<<< HEAD
        Task Adicionar(Horario horario);
=======
        Task Criar(Horario horario);
>>>>>>> feature/Gabriela
        Task Alterar(Horario horario);
        Task Deletar(Horario horario);
        Task<Horario> ObterHorario(int id);
        Task<List<Horario>> ObterTodosOsHorarios();
    }
}