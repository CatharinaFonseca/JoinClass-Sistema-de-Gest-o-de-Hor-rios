using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Disponibilidades.Request
{
    public class CriarDisponibilidadeRequest
    {
        public string horario_inicio { get; set; }
        public string horario_fim { get; set; }
        public int id_professor { get; set; }

        public List<string> dias { get; set; } // para aceitar o checkbox
    }
}