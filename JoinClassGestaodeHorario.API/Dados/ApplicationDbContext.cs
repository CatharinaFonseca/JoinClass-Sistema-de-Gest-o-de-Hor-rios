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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entidade =>
            {
                entidade.ToTable("Aluno", "public");
                entidade.Ignore(e => e.graduacao);
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Coordenador>(entidade =>
            {
                entidade.ToTable("Coordenador", "public");
                entidade.Ignore(e => e.disciplinas);
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Disciplina>(entidade =>
            {
                entidade.ToTable("Disciplina", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Disponibilidade>(entidade =>
            {
                entidade.ToTable("Disponibilidade", "public");
                entidade.Ignore(e => e.professor);
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Graduacao>(entidade =>
            {
                entidade.ToTable("Graduacao", "public");
                entidade.Ignore(e => e.disciplinas);
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Horario>(entidade =>
            {
                entidade.ToTable("Horario", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Pessoa>(entidade =>
            {
                entidade.ToTable("Pessoa", "public");
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Professor>(entidade =>
            {
                entidade.ToTable("Professor", "public");
                entidade.Ignore(e => e.disciplinas);
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Turma>(entidade =>
            {
                entidade.ToTable("Turma", "public");
                entidade.Ignore(e => e.horarios);
                entidade.HasKey(e => e.id);
            });
        }
    }
}