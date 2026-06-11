using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.MatrizesCurriculares.Request
{
    public class CriarMatrizRequest
    {
        public int id_graduacao { get; set; }
        public int id_semestre { get; set; }
        public int id_disponibilidade { get; set; }
        public int id_disciplina { get; set; }
    }
}