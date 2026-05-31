using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargHoraria { get; set; }

        public List<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}