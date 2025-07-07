using System.ComponentModel.DataAnnotations;

namespace Artistas.Models.DTOs
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
