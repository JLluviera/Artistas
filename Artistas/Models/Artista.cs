using System.ComponentModel.DataAnnotations;

namespace Artistas.Models
{
    public class Artista
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Nacionalidad { get; set; }
        [Required]
        public DateOnly FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public int? idCategoria { get; set; }

        public CategoriaArtistas? CategoriaArtista { get; set; }

        public int? IdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        public List<Espectaculo>? Espectaculos { get; set; } = new List<Espectaculo>();

    }
}
