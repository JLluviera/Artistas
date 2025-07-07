using Artistas.Helpers;
using Artistas.Models;
using Artistas.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using TuProyecto.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Artistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Autentica _autentica;

        public UsuarioController(AppDbContext context, Autentica autentica)
        {
            _context = context;
            _autentica = autentica;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Registrar([FromBody] UsuarioDTO user, int? id, string? ContraVieja)
        {
            if (user == null)
            { return BadRequest("El cuerpo no puede ser nulo"); };

            if (user.NombreUsuario == "string")
            {
                return BadRequest("el nombre no puede ser 'string'");
            };

            if (id == null)
            {
                Usuario? userContext = _context.Usuarios.FirstOrDefault(u => u.Email == user.Email);
                if (userContext != null)
                {
                    BadRequest("Este mail ya tiene un usuario asociado");
                }

                Usuario userNuevo = new Usuario
                {
                    NombreUsuario = user.NombreUsuario,
                    Email = user.Email,
                    PasswordHash = HelperConstraseña.EncryptContra(user.Password)
                };
                _context.Usuarios.Add(userNuevo);
                _context.SaveChanges();
                return Ok("Usuario registrado correctamente");
            }
            else
            {
                Usuario? usuarioContext = _context.Usuarios.FirstOrDefault(u => u.Id == id);
                if (usuarioContext == null)
                {
                    return BadRequest("El usuario no existe");
                };

                if (ContraVieja == null || HelperConstraseña.Verificar(ContraVieja, usuarioContext.PasswordHash))
                {
                    return BadRequest("La contraseña antigua no coincide con la registrada en el sistema");
                }

                usuarioContext.NombreUsuario = user.NombreUsuario;
                usuarioContext.Email = user.Email;
                usuarioContext.PasswordHash = HelperConstraseña.EncryptContra(user.Password);
                _context.Usuarios.Update(usuarioContext);
                _context.SaveChanges();
                return Ok("Usuario actualizado correctamente");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Usuarios = _context.Usuarios
                                    .Select(u => new RespuestaUsuarioDTO
                                    {
                                        Id = u.Id,
                                        NombreUsuario = u.NombreUsuario,
                                        Email = u.Email
                                    });

            if (!Usuarios.Any())
            {
                return Ok("No hay usuarios registrados");
            }

            return Ok(Usuarios);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<Usuario> PostLogin([FromBody] LoginUsuarioDTO loginUsuarioDTO)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Usuario? usuario = _context.Usuarios.FirstOrDefault(u => u.Email == loginUsuarioDTO.Email);
            

            if (usuario == null)
            {
                return Unauthorized("Usuario incorrecto");
            }

            if (!(HelperConstraseña.Verificar(loginUsuarioDTO.Password, usuario.PasswordHash)))
            {
                return Unauthorized("Contraseña incorrecta");
            }

            RespuestaLoginTokenDTO token = new RespuestaLoginTokenDTO();
            token.Token = _autentica.CrearToken(usuario);
            return Ok(token.Token);
        }

    }
}
