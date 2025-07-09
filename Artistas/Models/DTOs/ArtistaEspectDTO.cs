namespace Artistas.Models.DTOs
{
    public class ArtistaEspectDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string NombreUsuario { get; set; }

        public List<EspectaculoDTO> Espectaculos { get; set; } = new List<EspectaculoDTO>();
    }
}
