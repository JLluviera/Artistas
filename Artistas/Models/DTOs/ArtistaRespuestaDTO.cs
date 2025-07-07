namespace Artistas.Models.DTOs
{
    public class ArtistaRespuestaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string NombreUsuario { get; set; }
    }
}
