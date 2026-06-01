using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class TurmaAluno
    {
        public int idTurma { get; set; }
        public Turma Turma { get; set; }

        public int idAluno { get; set; }
        public Aluno Aluno { get; set; }
    }
}