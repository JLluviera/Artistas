using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TuProyecto.Data;
using Microsoft.EntityFrameworkCore;
using Artistas.Models;
using Artistas.Models.DTOs;

namespace Artistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EspectaculosController : ControllerBase
    {
        private protected readonly AppDbContext _context;

        public EspectaculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var espectaculos = _context.Espectaculos
                        .Include(e => e.Artista)
                        .ThenInclude(a => a.Usuario)
                        .Select(e => new EspectuloRespDTO
                        {
                            Id = e.Id,
                            Nombre = e.Nombre,
                            FechaHora = e.FechaHora,
                            IdArtista = e.IdArtista,
                            NombreArtista = e.Artista.Nombre,
                            GeneroArtista = e.Artista.Genero,
                            NacionalidadArtista = e.Artista.Nacionalidad
                        })
                        .ToList();

            if (espectaculos == null || !espectaculos.Any())
            {
                return NotFound("No hay espectáculos disponibles.");
            }
            return Ok(espectaculos);    
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var espect = _context.Espectaculos
                .Include(e => e.Artista)
                .Select(e => new EspectuloRespDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    FechaHora = e.FechaHora,
                    IdArtista = e.IdArtista,
                    NombreArtista = e.Artista.Nombre,
                    GeneroArtista = e.Artista.Genero,
                    NacionalidadArtista = e.Artista.Nacionalidad
                })
                .FirstOrDefault(e => e.Id == id);

            if (espect == null)
                return BadRequest("El espectáculo no existe.");

            return Ok(espect);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EspectaculoDTO espectaculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var artista = _context.Artistas.FirstOrDefault(a => a.Id == espectaculo.IdArtista );

            if (artista == null)
            {
                return BadRequest("El artista no existe.");
            };

            var nuevoEspectaculo = new Espectaculo
            {
                Nombre = espectaculo.Nombre,
                FechaHora = espectaculo.FechaHora,
                IdArtista = espectaculo.IdArtista,
                Artista = artista
            };

            _context.Espectaculos.Add(nuevoEspectaculo);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] EspectModDTO espectaculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var espect = _context.Espectaculos
                .Include(e => e.Artista)
                .FirstOrDefault(e => e.Id == espectaculo.Id);
            if (espect == null)
            {
                return BadRequest("El espectáculo no existe.");
            };

            var artista = _context.Artistas.FirstOrDefault(a => a.Id == espectaculo.IdArtista);
            if (artista == null)
            {
                return BadRequest("El artista no existe.");
            };

            espect.Nombre = espectaculo.Nombre;
            espect.FechaHora = espectaculo.FechaHora;

            if (espectaculo.IdArtista != espect.IdArtista)
            {
                var artistaViejo = _context.Artistas
                            .Include(a => a.Espectaculos)
                            .FirstOrDefault(a => a.Id == espect.IdArtista);
                if (artistaViejo != null)
                {
                    artistaViejo.Espectaculos.Remove(espect);
                }
               
            }

            espect.IdArtista = espectaculo.IdArtista;
            espect.Artista = artista;
            _context.Espectaculos.Update(espect);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var espect = _context.Espectaculos
                .Include(e => e.Artista)
                .FirstOrDefault(e => e.Id == id);
            if (espect == null)
            {
                return BadRequest("El espectáculo no existe.");
            }
            ;
            _context.Espectaculos.Remove(espect);
            _context.SaveChanges();
            return Ok();
        }
    }


}
