using System.ComponentModel.DataAnnotations;

namespace Artistas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public List<Artista>? ArtistasCreados { get; set; } = new List<Artista>();
    }
}
