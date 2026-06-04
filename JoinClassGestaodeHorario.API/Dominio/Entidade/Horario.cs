using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Horario
    {
        public int id { get; set; }
<<<<<<< HEAD
        public string dia_semana { get; set; }
        public string horario_inicio { get; set; }
        public string horario_fim { get; set; }
=======
        public string diaSemana { get; set; }
        public string horarioInicio { get; set; }
        public string horarioFim { get; set; }

        public int idTurma { get; set; }
        public Turma Turma { get; set; }
>>>>>>> feature/Gabriela
    }
}