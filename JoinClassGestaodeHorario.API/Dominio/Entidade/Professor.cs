using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Professor
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }

        public List<Disponibilidade> Disponibilidades { get; set; }
        public List<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}