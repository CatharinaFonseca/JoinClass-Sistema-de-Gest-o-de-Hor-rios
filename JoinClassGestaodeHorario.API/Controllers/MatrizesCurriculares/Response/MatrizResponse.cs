using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.MatrizesCurriculares.Response
{
    public class MatrizResponse
    {
        public int id { get; set; }
        public int id_graduacao { get; set; }
        public int id_semestre { get; set; }
        public int id_disponibilidade { get; set; }
        public int id_disciplina { get; set; }
        public string nome_disciplina { get; set; }
    }
}