using Microsoft.Build.Framework;

namespace Artistas.Models.DTOs
{
    public class ArtistaDTO
    {
        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        public string Genero { get; set; }

        [Required]
        public int idCategoria { get; set; }
    }
}
