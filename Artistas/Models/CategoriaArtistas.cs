namespace Artistas.Models
{
    public class CategoriaArtistas
    {
        public int id { get; set; }

        public string Descripcion { get; set; }

        public List<Artista> Artistas { get; set; } = new List<Artista>();

    }
}
