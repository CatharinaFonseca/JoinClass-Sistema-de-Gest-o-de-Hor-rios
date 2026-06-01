using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Horarios.Response
{
    public class HorarioResponse
    {
        public int id { get; set; }
        public string diaSemana { get; set; }
        public string horarioInicio { get; set; }
        public string horarioFim { get; set; }
        public int idTurma { get; set; }
    }
}