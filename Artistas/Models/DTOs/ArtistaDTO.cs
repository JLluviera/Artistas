using Microsoft.Build.Framework;

namespace Artistas.Models.DTOs
{
    public class ArtistaDTO
    {
        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public string Nacionalidad { get; set; }
        
        [Required]
        public DateOnly FechaNacimiento { get; set; }
        
        [Required]
        public string Genero { get; set; }

        [Required]
        public int idCategoria { get; set; }
    }
}
