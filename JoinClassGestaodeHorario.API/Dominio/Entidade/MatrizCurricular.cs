using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class MatrizCurricular
    {
        public int id { get; set; }
        public string nomeMatrizCurricular { get; set; }

        public int idGraduacao { get; set; }
        public Graduacao Graduacao { get; set; }

        public int idSemestre { get; set; }
        public Semestre Semestre { get; set; }

        public int idDisponibilidade { get; set; }
        public Disponibilidade Disponibilidade { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}