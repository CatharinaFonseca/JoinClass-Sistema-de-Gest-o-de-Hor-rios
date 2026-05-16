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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Graduacao>(entidade =>
            {
                entidade.ToTable("Graduacao", "public");
                entidade.Ignore(e => e.disciplinas);
                entidade.HasKey(e => e.id);
            });
        }

    }
}