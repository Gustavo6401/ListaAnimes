using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Context
{
    public class AnimeContext : DbContext
    {
        // public AnimeContext(DbContextOptions options) : base(options) { }
        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().HasKey(a => a.Id);

            modelBuilder.Entity<Anime>()
                .Property(a => a.Nome)
                    .HasMaxLength(150)
                        .IsRequired();

            modelBuilder.Entity<Anime>()
                .Property(a => a.EpQueParei)
                    .IsRequired();

            modelBuilder.Entity<Anime>()
                .Property(a => a.NumeroEpisodios)
                    .IsRequired();

            modelBuilder.Entity<Anime>()
                .Property(a => a.Status)
                    .HasMaxLength(20)
                        .IsRequired();
        }

        // Eu realmente não gosto de utilizar esse método, mas ou era isso, ou jogar a responsabilidade das migrations para a API.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AnimeDB;User Id=sa;Password=MyPass6401@gustavo;TrustServerCertificate=True");
        }

        public void Update(object entity) => Entry(entity).State = EntityState.Modified;
    }
}
