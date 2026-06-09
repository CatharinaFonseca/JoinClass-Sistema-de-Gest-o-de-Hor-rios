using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Horarios.Request
{
    public class CriarHorarioRequest
    {
        public string dia_semana { get; set; }
        public string horario_inicio { get; set; }
        public string horario_fim { get; set; }
        public int id_turma { get; set; }
    }
}