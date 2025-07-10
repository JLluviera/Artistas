namespace Artistas.Models.DTOs
{
    public class EspectuloRespDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdArtista { get; set; }
        public string NombreArtista { get; set; }

        public string GeneroArtista { get; set; }

        public string NacionalidadArtista { get; set; }

        public string NombreUsuario { get; set; }   
    }
}
