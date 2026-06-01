using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Turma
    {
        public int id { get; set; }

        public int idProfessor { get; set; }
        public Professor Professor { get; set; }

        public int idMatrizCurricular { get; set; }
        public MatrizCurricular MatrizCurricular { get; set; }

        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();

        public ICollection<TurmaAluno> TurmaAlunos { get; set; } = new List<TurmaAluno>();
    }
}