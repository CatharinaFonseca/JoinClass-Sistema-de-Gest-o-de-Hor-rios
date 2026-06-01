using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Disponibilidades.Request
{
    public class CriarDisponibilidadeRequest
    {
        public string diaSemana { get; set; }
        public string horarioInicio { get; set; }
        public string horarioFim { get; set; }
        public int idProfessor { get; set; }
    }
}