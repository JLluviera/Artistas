using System.ComponentModel.DataAnnotations;

namespace Artistas.Models.DTOs
{
    public class EspectaculoDTO
    {

        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public DateTime FechaHora { get; set; }
        
        [Required]
        public int IdArtista { get; set; }
    }
}
