using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Professor : Pessoa
    {
        public ICollection<Disponibilidade> Disponibilidades { get; set; } = new List<Disponibilidade>();
        public ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; } = new List<ProfessorDisciplina>();
    }
}