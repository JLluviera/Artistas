using System.ComponentModel.DataAnnotations;

namespace Artistas.Models.DTOs
{
    public class EspectModDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int IdArtista { get; set; }
    }
}
