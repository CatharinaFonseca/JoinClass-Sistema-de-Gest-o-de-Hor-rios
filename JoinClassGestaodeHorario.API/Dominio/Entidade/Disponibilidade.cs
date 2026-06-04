using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Disponibilidade
    {
        public int id { get; set; }
<<<<<<< HEAD
        public string dia_semana { get; set; }
        public string horario_inicio { get; set; }
        public string horario_fim { get; set; }
        public List<Professor> professor { get; set; }
=======
        public string diaSemana { get; set; }
        public string horarioInicio { get; set; }
        public string horarioFim { get; set; }

        public int idProfessor { get; set; }
        public Professor Professor { get; set; }
>>>>>>> feature/Gabriela
    }

}