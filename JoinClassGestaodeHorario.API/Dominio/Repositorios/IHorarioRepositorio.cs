using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
        public interface IHorarioRepositorio
        {
                Task Criar(Horario horario);
                Task Alterar(Horario horario);
                Task Deletar(Horario horario);
                Task<Horario> ObterHorario(int id);
                Task<List<Horario>> ObterTodosOsHorarios();
        }
}