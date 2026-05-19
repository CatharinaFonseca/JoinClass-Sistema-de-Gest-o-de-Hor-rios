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
        public DbSet<Graduacao> Graduacoes { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Graduacao>(entidade =>
            {
                entidade.ToTable("Graduacao", "public");
                entidade.Ignore(e => e.disciplinas);
                entidade.HasKey(e => e.id);
            });

            modelBuilder.Entity<Aluno>(entidade =>
            {
                entidade.ToTable("Aluno", "public");
                entidade.Ignore(e => e.graduacao);
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
        }
    }
}