using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Disciplinas.Request
{
    public class CriarDisciplinaRequest
    {
        public string nome { get; set; }
        public int carga_horaria { get; set; }
    }
}