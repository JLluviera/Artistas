using System.ComponentModel.DataAnnotations;

namespace Artistas.Models
{
    public class CategoriaArtistas
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public List<Artista> Artistas { get; set; } = new List<Artista>();

    }
}
