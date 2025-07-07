using Artistas.Models;
using Microsoft.EntityFrameworkCore;
using TuProyecto.Data;


namespace TuProyecto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Artista> Artistas { get; set; }

        public DbSet<CategoriaArtistas> CategoriaArtistas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Espectaculo> Espectaculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artista>()
                 .HasOne(a => a.CategoriaArtista)
                 .WithMany(c => c.Artistas)
                 .HasForeignKey(a => a.idCategoria)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Artista>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.ArtistasCreados)
                .HasForeignKey(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.ArtistasCreados)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Espectaculo>()
                .HasOne(e => e.Artista)
                .WithMany(a => a.Espectaculos)
                .HasForeignKey(e => e.IdArtista)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}