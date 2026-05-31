using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class TurmaAluno
    {
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }

        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
    }
}