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
        [Required]
        public int idCategoria { get; set; }

        public CategoriaArtistas CategoriaArtista { get; set; }

    }
}
