using System.ComponentModel.DataAnnotations;

namespace Artistas.Models
{
    public class Espectaculo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public int IdArtista { get; set; }

        public Artista Artista { get; set; }
    }
}
