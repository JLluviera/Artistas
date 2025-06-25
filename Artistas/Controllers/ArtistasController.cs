using Microsoft.AspNetCore.Mvc;
using Artistas.Models;
using TuProyecto.Data;
using Artistas.Models.DTOs;
using System.Linq.Expressions;

namespace Artistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                return NotFound();
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
        public IActionResult Post([FromBody] ArtistaDTO artista, int? id)
        {
            if (artista == null)
            {
                return BadRequest("El artista no puede ser nulo.");
            };

            Artista? artistaContext = _context.Artistas.FirstOrDefault(a => a.Id == id);

            if (artistaContext == null)
            {
                return BadRequest("Ese artista no existe");
            }

            if(artista.Nombre == null || artista.Nombre.Trim() == "" || artista.Nombre == "string")
            {
                return BadRequest("El nombre del artista no puede estar vacío.");
            }

            if (artista.Nacionalidad == null || artista.Nacionalidad.Trim() == "")
            {
                return BadRequest("La nacionalidad del artista no puede estar vacía.");
            }

            if(artista.FechaNacimiento == default(DateOnly))
            {
                return BadRequest("La fecha de nacimiento del artista no puede ser nula.");
            }

            var nuevoArtista = new Artista
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

            if (id != null)
            {
                nuevoArtista.Id = (int)id;
                _context.Artistas.Update(nuevoArtista);
                
            }
            else
            {
                _context.Artistas.Add(nuevoArtista);
                cat.Artistas.Add(nuevoArtista);
            }

            try
            {
                _context.SaveChanges();
                return Ok(artista);
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

            _context.Artistas.Remove(artista);
            _context.SaveChanges();
            return Ok("Eliminado");
        }
    }
}
