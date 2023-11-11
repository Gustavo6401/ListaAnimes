using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Context
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions options) : base(options) { }
        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().HasKey(a => a.Id);

            modelBuilder.Entity<Anime>()
                .Property(a => a.Nome)
                    .HasMaxLength()
        }
    }
}
