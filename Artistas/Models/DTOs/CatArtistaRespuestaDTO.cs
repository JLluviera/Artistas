namespace Artistas.Models.DTOs
{
    public class CatArtistaRespuestaDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public List<ArtistaRespuestaDTO> ArtistasSimples { get; set; } 
    }
}
