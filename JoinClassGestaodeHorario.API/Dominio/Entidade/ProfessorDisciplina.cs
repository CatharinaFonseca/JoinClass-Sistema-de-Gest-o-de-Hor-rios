using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class ProfessorDisciplina
    {
        public int id_professor { get; set; }
        public Professor Professor { get; set; }

        public int id_disciplina { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}