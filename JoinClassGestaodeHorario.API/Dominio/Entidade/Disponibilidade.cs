using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Disponibilidade
    {
        public int id { get; set; }
        public string diaSemana { get; set; }
        public string horarioInicio { get; set; }
        public string horarioFim { get; set; }

        public int idProfessor { get; set; }
        public Professor Professor { get; set; }
    }

}