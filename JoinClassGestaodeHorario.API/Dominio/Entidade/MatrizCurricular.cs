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
        public Graduacao Graduacao { get; set; }

        [Column("id_semestre")] // Garantindo o mapeamento correto do nome da coluna no banco
        public int id_semestre { get; set; }
        public Semestre Semestre { get; set; }

        [Column("id_disponibilidade")] // Garantindo o mapeamento correto do nome da coluna no banco
        public int id_disponibilidade { get; set; }
        public Disponibilidade Disponibilidade { get; set; }

        [Column("id_disciplina")] // Garantindo o mapeamento correto do nome da coluna no banco
        public int id_disciplina { get; set; }
        public Disciplina Disciplina { get; set; }

        // 🔥 O TRUQUE DE OURO: Avisa ao EF que esta lista se conecta 
        // diretamente à propriedade "MatrizCurricular" definida na classe Turma
        [InverseProperty("MatrizCurricular")]
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}