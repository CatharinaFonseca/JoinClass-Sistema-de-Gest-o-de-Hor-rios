using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class ProfessorDisciplina
    {
        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }

        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}