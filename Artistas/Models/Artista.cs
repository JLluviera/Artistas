namespace Artistas.Models
{
    public class Artista
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public int idCategoria { get; set; }

        public CategoriaArtistas CategoriaArtista { get; set; }

    }
}
