using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class ProfessorDisciplina
    {
        public int idProfessor { get; set; }
        public Professor Professor { get; set; }

        public int idDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}