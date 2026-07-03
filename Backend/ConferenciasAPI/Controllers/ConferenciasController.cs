using ConferenciasAPI.Data;
using ConferenciasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenciasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConferenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Conferencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conferencia>>> GetConferencias()
        {
            return await _context.Conferencias.ToListAsync();
        }

        // GET: api/Conferencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conferencia>> GetConferencia(int id)
        {
            var conferencia = await _context.Conferencias.FindAsync(id);

            if (conferencia == null)
                return NotFound();

            return conferencia;
        }

        // POST: api/Conferencias
        [HttpPost]
        public async Task<ActionResult<Conferencia>> PostConferencia(Conferencia conferencia)
        {
            _context.Conferencias.Add(conferencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConferencia), new { id = conferencia.conferencia_id }, conferencia);
        }

        // PUT: api/Conferencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConferencia(int id, Conferencia conferencia)
        {
            if (id != conferencia.conferencia_id)
                return BadRequest();

            _context.Entry(conferencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Conferencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferencia(int id)
        {
            var conferencia = await _context.Conferencias.FindAsync(id);

            if (conferencia == null)
                return NotFound();

            _context.Conferencias.Remove(conferencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}