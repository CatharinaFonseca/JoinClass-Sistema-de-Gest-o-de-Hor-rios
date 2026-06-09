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

        public int id_graduacao { get; set; }
        public Graduacao Graduacao { get; set; }

        public int id_semestre { get; set; }
        public Semestre Semestre { get; set; }

        public int id_disponibilidade { get; set; }
        public Disponibilidade Disponibilidade { get; set; }
        public int id_disciplina { get; set; }
        public Disciplina Disciplina { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}