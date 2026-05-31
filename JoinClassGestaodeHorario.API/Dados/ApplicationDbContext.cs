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
            modelBuilder.Entity<Aluno>(entidade =>
            {
                entidade.ToTable("Aluno", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(a => a.Pessoa)
                    .WithOne()
                    .HasForeignKey<Aluno>(a => a.Id);
            });

            modelBuilder.Entity<Coordenador>(entidade =>
            {
                entidade.ToTable("Coordenador", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(c => c.Pessoa)
                    .WithOne()
                    .HasForeignKey<Coordenador>(c => c.Id);
            });

            modelBuilder.Entity<Disciplina>(entidade =>
            {
                entidade.ToTable("Disciplina", "public");
                entidade.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Disponibilidade>(entidade =>
            {
                entidade.ToTable("Disponibilidade", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(d => d.Professor)
                        .WithMany(p => p.Disponibilidades)
                        .HasForeignKey(d => d.IdProfessor);
            });

            modelBuilder.Entity<Graduacao>(entidade =>
            {
                entidade.ToTable("Graduacao", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(g => g.Coordenador)
                    .WithMany(c => c.Graduacoes)
                    .HasForeignKey(g => g.IdCoordenador);
            });

            modelBuilder.Entity<Horario>(entidade =>
            {
                entidade.ToTable("Horario", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(h => h.Turma)
                    .WithMany(t => t.Horarios)
                    .HasForeignKey(h => h.IdTurma);
            });

            modelBuilder.Entity<MatrizCurricular>(entidade =>
            {
                entidade.ToTable("Matriz_curricular", "public");
                entidade.HasKey(e => e.Id);

                entidade.HasOne(m => m.Graduacao)
                    .WithMany(g => g.Matrizes)
                    .HasForeignKey(m => m.IdGraduacao);

                entidade.HasOne(m => m.Semestre)
                    .WithMany()
                    .HasForeignKey(m => m.IdSemestre);

                entidade.HasOne(m => m.Disponibilidade)
                    .WithMany()
                    .HasForeignKey(m => m.IdDisponibilidade);
            });


            modelBuilder.Entity<Pessoa>(entidade =>
            {
                entidade.ToTable("Pessoa", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Professor>(entidade =>
            {
                entidade.ToTable("Professor", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(p => p.Pessoa)
                    .WithOne()
                    .HasForeignKey<Professor>(p => p.Id);
            });

            modelBuilder.Entity<ProfessorDisciplina>(entidade =>
           {
               entidade.ToTable("Professor_Disciplina", "public");

               entidade.HasKey(pd => new { pd.IdProfessor, pd.IdDisciplina });

               entidade.HasOne(pd => pd.Professor)
                   .WithMany(p => p.ProfessorDisciplinas)
                   .HasForeignKey(pd => pd.IdProfessor);

               entidade.HasOne(pd => pd.Disciplina)
                   .WithMany(d => d.ProfessorDisciplinas)
                   .HasForeignKey(pd => pd.IdDisciplina);
           });

            modelBuilder.Entity<Semestre>(entidade =>
            {
                entidade.ToTable("Semestre", "public");
                entidade.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Titulacao>(entidade =>
            {
                entidade.ToTable("Titulacao", "public");
                entidade.HasKey(e => e.Id);

                entidade.HasOne(t => t.Professor)
                    .WithMany()
                    .HasForeignKey(t => t.IdProfessor);
            });

            modelBuilder.Entity<Turma>(entidade =>
            {
                entidade.ToTable("Turma", "public");

                entidade.HasKey(e => e.Id);

                entidade.HasOne(t => t.Professor)
                        .WithMany()
                        .HasForeignKey(t => t.IdProfessor);

                entidade.HasOne(t => t.MatrizCurricular)
                        .WithMany()
                        .HasForeignKey(t => t.IdMatrizCurricular);
            });

            modelBuilder.Entity<TurmaAluno>(entidade =>
            {
                entidade.ToTable("Turma_Aluno", "public");

                entidade.HasKey(ta => new { ta.IdTurma, ta.IdAluno });

                entidade.HasOne(ta => ta.Turma)
                    .WithMany(t => t.TurmaAlunos)
                    .HasForeignKey(ta => ta.IdTurma);

                entidade.HasOne(ta => ta.Aluno)
                    .WithMany(a => a.TurmaAlunos)
                    .HasForeignKey(ta => ta.IdAluno);
            });
        }
    }
}