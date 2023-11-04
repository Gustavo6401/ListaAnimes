using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Contexto
{
    // Essa Classe só será acessada pela camada "Repositórios"
    internal class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options) { }
        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().HasKey(a => a.Id);

            modelBuilder.Entity<Anime>()
                .Property(a => a.Nome)
                    .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Anime>()
                .Property(a => a.NumeroEpisodios)
                    .IsRequired();

            modelBuilder.Entity<Anime>()
                .Property(a => a.Status)
                    .HasMaxLength(20)
                        .IsRequired();
        }

        public virtual void Modify(object entity) => Entry(entity).State = EntityState.Modified;
    }
}
