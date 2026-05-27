using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Disciplinas.Response
{
    public class DisciplinaResponse
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
    }
}