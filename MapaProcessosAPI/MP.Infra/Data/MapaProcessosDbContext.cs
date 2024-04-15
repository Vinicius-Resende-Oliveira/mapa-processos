using Microsoft.EntityFrameworkCore;
using MP.Domain.Entities;
using MP.Infra.Configuration;

namespace MP.Infra.Data
{
    public class MapaProcessosDbContext : DbContext
    {
        public MapaProcessosDbContext(DbContextOptions options) 
            : base(options)
        { }

        public DbSet<Processo> Processos => Set<Processo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProcessoConfiguration());
        }
    }
}
