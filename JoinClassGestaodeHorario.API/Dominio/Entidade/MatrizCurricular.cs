using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    [Table("matriz_curricular", Schema = "public")]
    public class MatrizCurricular
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("id_graduacao")]
        public int id_graduacao { get; set; }
        [ForeignKey("id_graduacao")]
        public Graduacao Graduacao { get; set; }

        [Column("id_semestre")]
        public int id_semestre { get; set; }
        [ForeignKey("id_semestre")]
        public Semestre Semestre { get; set; }

        [Column("id_disponibilidade")]
        public int id_disponibilidade { get; set; }
        [ForeignKey("id_disponibilidade")]
        public Disponibilidade Disponibilidade { get; set; }

        [Column("id_disciplina")]
        public int id_disciplina { get; set; }
        [ForeignKey("id_disciplina")]
        public Disciplina Disciplina { get; set; }

        [InverseProperty("MatrizCurricular")]
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}