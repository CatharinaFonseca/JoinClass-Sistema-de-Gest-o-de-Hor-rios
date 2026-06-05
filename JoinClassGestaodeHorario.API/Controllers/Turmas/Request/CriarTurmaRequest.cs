using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Turmas.Request
{
    public class CriarTurmaRequest
    {
        public int id_professor { get; set; }
        public int idMatrizCurricular { get; set; }
    }
}