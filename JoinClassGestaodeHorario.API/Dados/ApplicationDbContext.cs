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
        public DbSet<MatrizCurricular> MatrizCurriculars { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<TurmaAluno> TurmaAlunos { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public DbSet<Titulacao> Titulacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>()
                .ToTable("Pessoa", "public");

            modelBuilder.Entity<Aluno>()
                .ToTable("Aluno", "public");

            modelBuilder.Entity<Professor>()
                .ToTable("Professor", "public");

            modelBuilder.Entity<Coordenador>()
                .ToTable("Coordenador", "public");

            modelBuilder.Entity<Disciplina>(entidade =>
            {
                entidade.ToTable("Disciplina", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Disponibilidade>(entidade =>
            {
                entidade.ToTable("Disponibilidade", "public");

                entidade.HasKey(e => e.id);

                entidade.HasOne(d => d.Professor)
                        .WithMany(p => p.Disponibilidades)
                        .HasForeignKey(d => d.idProfessor);
            });

            modelBuilder.Entity<Graduacao>(entidade =>
            {
                entidade.ToTable("Graduacao", "public");

                entidade.HasKey(e => e.id);

                entidade.HasOne(g => g.Coordenador)
                    .WithMany(c => c.Graduacoes)
                    .HasForeignKey(g => g.idCoordenador);
            });

            modelBuilder.Entity<Horario>(entidade =>
            {
                entidade.ToTable("Horario", "public");

                entidade.HasKey(e => e.id);

                entidade.HasOne(h => h.Turma)
                    .WithMany(t => t.Horarios)
                    .HasForeignKey(h => h.idTurma);
            });

            modelBuilder.Entity<MatrizCurricular>(entidade =>
            {
                entidade.ToTable("Matriz_curricular", "public");
                entidade.HasKey(e => e.id);

                entidade.HasOne(m => m.Graduacao)
                    .WithMany(g => g.Matrizes)
                    .HasForeignKey(m => m.idGraduacao);

                entidade.HasOne(m => m.Semestre)
                    .WithMany()
                    .HasForeignKey(m => m.idSemestre);

                entidade.HasOne(m => m.Disponibilidade)
                    .WithMany()
                    .HasForeignKey(m => m.idDisponibilidade);
            });

            modelBuilder.Entity<ProfessorDisciplina>(entidade =>
           {
               entidade.ToTable("Professor_Disciplina", "public");

               entidade.HasKey(pd => new { pd.idProfessor, pd.idDisciplina });

               entidade.HasOne(pd => pd.Professor)
                   .WithMany(p => p.ProfessorDisciplinas)
                   .HasForeignKey(pd => pd.idProfessor);

               entidade.HasOne(pd => pd.Disciplina)
                   .WithMany(d => d.ProfessorDisciplinas)
                   .HasForeignKey(pd => pd.idDisciplina);
           });

            modelBuilder.Entity<Semestre>(entidade =>
            {
                entidade.ToTable("Semestre", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Titulacao>(entidade =>
            {
                entidade.ToTable("Titulacao", "public");
                entidade.HasKey(e => e.id);

                entidade.HasOne(t => t.Professor)
                    .WithMany()
                    .HasForeignKey(t => t.idProfessor);
            });

            modelBuilder.Entity<Turma>(entidade =>
            {
                entidade.ToTable("Turma", "public");

                entidade.HasKey(e => e.id);

                entidade.HasOne(t => t.Professor)
                        .WithMany()
                        .HasForeignKey(t => t.idProfessor);

                entidade.HasOne(t => t.MatrizCurricular)
                        .WithMany()
                        .HasForeignKey(t => t.idMatrizCurricular);
            });

            modelBuilder.Entity<TurmaAluno>(entidade =>
            {
                entidade.ToTable("Turma_Aluno", "public");

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