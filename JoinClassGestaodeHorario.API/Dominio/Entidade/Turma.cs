using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Turma
    {
        public int id { get; set; }
        public List<Aluno> alunos { get; set; }
        public List<Professor> professores { get; set; }
        public List<Horario> horarios { get; set; }
    }
}