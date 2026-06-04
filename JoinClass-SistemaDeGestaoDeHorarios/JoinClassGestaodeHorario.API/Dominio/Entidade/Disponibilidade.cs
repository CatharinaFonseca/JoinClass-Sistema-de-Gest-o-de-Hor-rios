using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Disponibilidade : Calendario
    {
        public List<Professor> professor { get; set; }
    }

}