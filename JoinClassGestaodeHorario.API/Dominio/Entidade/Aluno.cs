using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Aluno : Pessoa
    {
        public ICollection<TurmaAluno> TurmaAlunos { get; set; } = new List<TurmaAluno>();
    }
}