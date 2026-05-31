using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class MatrizCurricular
    {
        public int Id { get; set; }
        public string NomeMatrizCurricular { get; set; }

        public int IdGraduacao { get; set; }
        public Graduacao Graduacao { get; set; }

        public int IdSemestre { get; set; }
        public Semestre Semestre { get; set; }

        public int IdDisponibilidade { get; set; }
        public Disponibilidade Disponibilidade { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}