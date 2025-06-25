using Artistas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using TuProyecto.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Artistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaArtistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaArtistasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categorias = _context.CategoriaArtistas
                            .ToList();
            if (categorias == null || !categorias.Any())
            {
                return NotFound();
            }
            return Ok(categorias);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var categoria = _context.CategoriaArtistas
                            .FirstOrDefault(c => c.id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string Descripcion)
        {
            if (string.IsNullOrEmpty(Descripcion))
            { return BadRequest("La descripción no puede estar vacía."); }

            var nuevaCategoria = new CategoriaArtistas();
            nuevaCategoria.Descripcion = Descripcion;
            _context.CategoriaArtistas.Add(nuevaCategoria);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<CategoriaArtistasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string Descripcion)
        {
            var categoria = _context.CategoriaArtistas
                            .FirstOrDefault(c => c.id == id);
            if (categoria == null)
            {
                return NotFound();
            };

            categoria.Descripcion = Descripcion;
            _context.CategoriaArtistas.Update(categoria);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<CategoriaArtistasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var categoria = _context.CategoriaArtistas
                            .FirstOrDefault(c => c.id == id);
            if (categoria != null)
            {
                _context.CategoriaArtistas.Remove(categoria);
                _context.SaveChanges();
            }
            else
            {
                NotFound();
            }
        }
    }
}
