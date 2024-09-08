using Microsoft.EntityFrameworkCore;
using TP3._11.Models;

namespace TP3._11.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Passaporte> Passaportes { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                  .HasOne(p => p.Passaporte)
                  .WithOne(e => e.Pessoa)
                  .HasForeignKey<Passaporte>(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
