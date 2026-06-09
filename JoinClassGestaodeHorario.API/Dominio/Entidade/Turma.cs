using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
        [Table("turma", Schema = "public")]
        public class Turma
        {
                [Key]
                [Column("id")]
                public int id { get; set; }

                [Column("id_matriz_curricular")]
                public int? id_matriz_curricular { get; set; }

                // Esta anotação força o EF a vincular a navegação DIRETAMENTE ao campo minúsculo
                [ForeignKey("id_matriz_curricular")]
                public MatrizCurricular MatrizCurricular { get; set; }

                [Column("id_professor")]
                public int id_professor { get; set; }

                [ForeignKey("id_professor")]
                public Professor Professor { get; set; }

                [Column("id_disciplina")]
                public int id_disciplina { get; set; }

                [ForeignKey("id_disciplina")]
                public Disciplina Disciplina { get; set; }

                public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
                public ICollection<TurmaAluno> TurmaAlunos { get; set; } = new List<TurmaAluno>();
        }
}