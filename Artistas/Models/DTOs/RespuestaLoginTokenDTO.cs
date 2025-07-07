using System.ComponentModel.DataAnnotations;

namespace Artistas.Models.DTOs
{
    public class RespuestaLoginTokenDTO
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
