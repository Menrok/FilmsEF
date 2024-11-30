using Microsoft.EntityFrameworkCore;

namespace Filmy_EF.Models
{
    public class FilmsDbContext : DbContext
    {
        public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options)
        {
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed dla kategorii
            modelBuilder.Entity<Kategoria>().HasData(
            new Kategoria { Id = 1, Name = "Komedia" },
            new Kategoria { Id = 2, Name = "Akcja" },
            new Kategoria { Id = 3, Name = "Dramat" }
            );
            // Seed dla filmów
            modelBuilder.Entity<Film>().HasData(
            new Film
            {
                ID = 1,
                Tytul = "Film 1",
                Opis = "Opis 1",
                Ocena = 5,
                KategoriaId = 1
            },
            new Film
            {
                ID = 2,
                Tytul = "Film 2",
                Opis = "Opis 2",
                Ocena = 3,
                KategoriaId = 2
            }
            );
        }
    }
}