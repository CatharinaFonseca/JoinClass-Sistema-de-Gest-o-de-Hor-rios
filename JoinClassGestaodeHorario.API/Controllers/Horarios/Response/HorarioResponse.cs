using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Horarios.Response
{
    public class HorarioResponse
    {
        public int id { get; set; }
        public string DiaSemana { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
        public int IdTurma { get; set; }
    }
}