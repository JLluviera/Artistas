using Microsoft.AspNetCore.Mvc;
using Artistas.Models;
using TuProyecto.Data;
using Artistas.Models.DTOs;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Artistas.Helpers;
using Microsoft.DiaSymReader;
using System.Security.Claims;

namespace Artistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArtistasController : ControllerBase
    {
        private protected readonly AppDbContext _context;

        public ArtistasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var artistas = _context.Artistas
                            .ToList();

            if (artistas == null || !artistas.Any())
            {
                return NotFound("No hay artistas");
            }

            return Ok(artistas);
        }

        // GET api/<ArtistasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var artista = _context.Artistas
                            .FirstOrDefault(a => a.Id == id);
            if (artista == null)
            {
                return NotFound();
            }

            return Ok(artista);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArtistaDTO artista)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || userId == string.Empty)
                return Unauthorized("No se ha encontrado el usuario");

            Usuario? user = _context.Usuarios
                .FirstOrDefault(u => u.Id == int.Parse(userId));

            if (user == null)
                return BadRequest("El usuario no existe mas");

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            ;
            Artista nuevoArtista = new Artista
            {
                Nombre = artista.Nombre,
                Nacionalidad = artista.Nacionalidad,
                FechaNacimiento = artista.FechaNacimiento,
                Genero = artista.Genero,
                idCategoria = artista.idCategoria
            };
            CategoriaArtistas? cat = _context.CategoriaArtistas
                .FirstOrDefault(c => c.id == artista.idCategoria);
            if (cat == null)
            {
                return BadRequest("La categoria no existe");
            }
            cat.Artistas.Add(nuevoArtista);

            nuevoArtista.IdUsuario = user.Id;
            nuevoArtista.Usuario = user;

            user.ArtistasCreados.Add(nuevoArtista);

            _context.Artistas.Add(nuevoArtista);

            try
            {
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message ?? ex.Message);
            }
            ;
        }


        [HttpPost("{id}")]
        public IActionResult Post([FromBody] ArtistaDTO artista, int id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || userId == string.Empty)
                return Unauthorized("No se ha encontrado el usuario autorizado");

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            };

            Artista? artistaContext = _context.Artistas.FirstOrDefault(a => a.Id == id);

            if (artistaContext == null)
            {
                return BadRequest("Ese artista no existe");
            }
           
            artistaContext.Nombre = artista.Nombre;
            artistaContext.Nacionalidad = artista.Nacionalidad;
            artistaContext.FechaNacimiento = artista.FechaNacimiento;
            artistaContext.Genero = artista.Genero;            

            CategoriaArtistas? cat = _context.CategoriaArtistas
                .FirstOrDefault(c => c.id == artista.idCategoria);

            if (cat == null)
            {
                return BadRequest("La categoria no existe");
            };

            if (artistaContext.idCategoria != artista.idCategoria)
            {
                CategoriaArtistas? catVieja = _context.CategoriaArtistas
                    .FirstOrDefault(c => c.id == artistaContext.idCategoria);
                if (catVieja != null)
                {
                    catVieja.Artistas.Remove(artistaContext);
                }
                cat.Artistas.Add(artistaContext);
            }

            artistaContext.idCategoria = artista.idCategoria;

            _context.Artistas.Update(artistaContext);        
            
            try
            {
                _context.SaveChanges();
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };

        }        
        
        // DELETE api/<ArtistasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var artista = _context.Artistas
                          .FirstOrDefault(a => a.Id == id);
                if (artista == null)
                {
                    return BadRequest("No existe el artista");
                }

            CategoriaArtistas? cat = _context.CategoriaArtistas
                .FirstOrDefault(c => c.id == artista.idCategoria);

            if (cat != null)
            {
                cat.Artistas.Remove(artista);
            }
        

            _context.Artistas.Remove(artista);
            _context.SaveChanges();
            return Ok("Eliminado");
        }
    }
}
