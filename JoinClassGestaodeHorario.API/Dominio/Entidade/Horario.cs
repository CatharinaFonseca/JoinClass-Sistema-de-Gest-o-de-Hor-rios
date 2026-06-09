using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
        public class Horario
        {
                public int id { get; set; }
                public string dia_semana { get; set; }
                public string horario_inicio { get; set; }
                public string horario_fim { get; set; }

                public int id_turma { get; set; }
                public Turma Turma { get; set; }

                public int id_disciplina { get; set; }
                public int id_professor { get; set; }
        }
}