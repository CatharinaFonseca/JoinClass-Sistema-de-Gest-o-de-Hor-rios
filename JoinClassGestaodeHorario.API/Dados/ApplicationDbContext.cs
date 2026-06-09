using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Graduacao> Graduacoes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        //  public DbSet<MatrizCurricular> MatrizCurriculars { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<TurmaAluno> TurmaAlunos { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public DbSet<Titulacao> Titulacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Pessoa>()
               .ToTable("pessoa", "public");

            modelBuilder.Entity<Aluno>()
                .ToTable("aluno", "public");

            modelBuilder.Entity<Professor>()
                .ToTable("professor", "public");

            modelBuilder.Entity<Coordenador>()
                .ToTable("coordenador", "public");

            modelBuilder.Entity<Disciplina>(entidade =>
            {
                entidade.ToTable("disciplina", "public");
                entidade.HasKey(e => e.id);
                entidade.Property(x => x.id).HasColumnName("id");
                entidade.Property(x => x.nome).HasColumnName("nome");
            });

            modelBuilder.Entity<Disponibilidade>(entidade =>
            {
                entidade.ToTable("disponibilidade", "public");

                entidade.HasKey(e => e.id);

                entidade.HasOne(d => d.Professor)
                        .WithMany(p => p.Disponibilidades)
                        .HasForeignKey(d => d.id_professor);
            });

            modelBuilder.Entity<Graduacao>(entidade =>
            {
                entidade.ToTable("graduacao", "public");

                entidade.HasKey(e => e.id);

                entidade.Property(e => e.nomeGraduacao)
                    .HasColumnName("nome_graduacao");

                entidade.Property(e => e.duracaoGraduacao)
                    .HasColumnName("duracao_graduacao");

                entidade.Property(e => e.qntAulaGraduacao)
                    .HasColumnName("qnt_aula_graduacao");

                entidade.Property(e => e.idCoordenador)
                    .HasColumnName("id_coordenador");

                entidade.HasOne(g => g.Coordenador)
                    .WithMany(c => c.Graduacoes)
                    .HasForeignKey(g => g.idCoordenador);
            });

            modelBuilder.Entity<Horario>(entidade =>
            {
                entidade.ToTable("horario", "public");

                entidade.HasKey(e => e.id);

                entidade.HasOne(h => h.Turma)
                    .WithMany(t => t.Horarios)
                    .HasForeignKey(h => h.id_turma);
            });

            /* modelBuilder.Entity<MatrizCurricular>(entidade =>
             {
                 entidade.ToTable("matriz_curricular", "public");
                 entidade.HasKey(e => e.id);

                 entidade.HasOne(m => m.Graduacao)
                     .WithMany(g => g.Matrizes)
                     .HasForeignKey(m => m.id_graduacao);

                 entidade.HasOne(m => m.Semestre)
                     .WithMany()
                     .HasForeignKey(m => m.id_semestre);

                 entidade.HasOne(m => m.Disponibilidade)
                     .WithMany()
                     .HasForeignKey(m => m.id_disponibilidade);
             });*/

            modelBuilder.Entity<ProfessorDisciplina>(entidade =>
           {
               entidade.ToTable("professor_disciplina", "public");

               entidade.HasKey(pd => new { pd.id_professor, pd.id_disciplina });

               entidade.HasOne(pd => pd.Professor)
                   .WithMany(p => p.ProfessorDisciplinas)
                   .HasForeignKey(pd => pd.id_professor);

               entidade.HasOne(pd => pd.Disciplina)
                   .WithMany(d => d.ProfessorDisciplinas)
                   .HasForeignKey(pd => pd.id_disciplina);
           });

            modelBuilder.Entity<Semestre>(entidade =>
            {
                entidade.ToTable("semestre", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Titulacao>(entidade =>
            {
                entidade.ToTable("titulacao", "public");
                entidade.HasKey(e => e.id);

                entidade.HasOne(t => t.Professor)
                    .WithMany()
                    .HasForeignKey(t => t.id_professor);
            });

            modelBuilder.Entity<Turma>(entidade =>
 {
     entidade.ToTable("turma", "public");

     entidade.HasKey(e => e.id);

     entidade.HasOne(t => t.Professor)
         .WithMany()
         .HasForeignKey(t => t.id_professor);

     entidade.HasOne(t => t.Disciplina)
         .WithMany()
         .HasForeignKey(t => t.id_disciplina);

     entidade.Property(x => x.id_disciplina).HasColumnName("id_disciplina");
     entidade.Property(x => x.id_professor).HasColumnName("id_professor");
 });

            modelBuilder.Entity<TurmaAluno>(entidade =>
            {
                entidade.ToTable("turma_aluno", "public");

                entidade.HasKey(ta => new { ta.idTurma, ta.idAluno });

                entidade.HasOne(ta => ta.Turma)
                    .WithMany(t => t.TurmaAlunos)
                    .HasForeignKey(ta => ta.idTurma);

                entidade.HasOne(ta => ta.Aluno)
                    .WithMany(a => a.TurmaAlunos)
                    .HasForeignKey(ta => ta.idAluno);
            });
        }
    }
}