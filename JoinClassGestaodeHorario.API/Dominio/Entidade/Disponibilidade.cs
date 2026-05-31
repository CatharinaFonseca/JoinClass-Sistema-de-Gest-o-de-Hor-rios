using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }

        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
    }

}