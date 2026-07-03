using ConferenciasAPI.Data;
using ConferenciasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsistentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Asistentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asistente>>> GetAsistentes()
        {
            return await _context.Asistentes
                .Include(a => a.Conferencia)
                .ToListAsync();
        }

        // GET: api/Asistentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asistente>> GetAsistente(int id)
        {
            var asistente = await _context.Asistentes.FindAsync(id);

            if (asistente == null)
                return NotFound();

            return asistente;
        }

        // POST: api/Asistentes
        [HttpPost]
        public async Task<ActionResult<Asistente>> PostAsistente(Asistente asistente)
        {
            _context.Asistentes.Add(asistente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsistente), new { id = asistente.asistente_id }, asistente);
        }

        // PUT: api/Asistentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistente(int id, Asistente asistente)
        {
            if (id != asistente.asistente_id)
                return BadRequest();

            _context.Entry(asistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Asistentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistente(int id)
        {
            var asistente = await _context.Asistentes.FindAsync(id);

            if (asistente == null)
                return NotFound();

            _context.Asistentes.Remove(asistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}