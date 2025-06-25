using Artistas.Models;
using Microsoft.EntityFrameworkCore;
using TuProyecto.Data;


namespace TuProyecto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define el DbSet para tu modelo
        public DbSet<Artista> Artistas { get; set; }

        public DbSet<CategoriaArtistas> CategoriaArtistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artista>()
                .HasOne(a => a.CategoriaArtista)
                .WithMany(c => c.Artistas)
                .HasForeignKey(a => a.idCategoria)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CategoriaArtistas>()
                .HasMany(c => c.Artistas)
                .WithOne(a => a.CategoriaArtista)
                .HasForeignKey(a => a.idCategoria)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}