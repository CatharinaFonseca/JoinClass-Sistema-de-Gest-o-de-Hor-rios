using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Turma
    {
        public int Id { get; set; }

        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }

        public int IdMatrizCurricular { get; set; }
        public MatrizCurricular MatrizCurricular { get; set; }

        public List<Horario> Horarios { get; set; }

        public List<TurmaAluno> TurmaAlunos { get; set; }
    }
}