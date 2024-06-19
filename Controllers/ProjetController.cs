using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRELLOBACK.Models;
using TRELLOBACK.Context;

namespace TRELLOBACK.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly TrellowiContext _context;

        public ProjetController(TrellowiContext context)
        {
            _context = context;
        }

        // GET: api/Projet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projet>>> GetProjets()
        {
            var ok = await _context.Projets.ToListAsync();
            return ok;
        }

        // GET: api/Projet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projet>> GetProjet(int id)
        {
            var projet = await _context.Projets.FindAsync(id);

            if (projet == null)
            {
                return NotFound();
            }

            return projet;
        }

        // POST: api/Projet
        [HttpPost]
        public async Task<ActionResult<Projet>> PostProjet(Projet projet)
        {
            _context.Projets.Add(projet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjet), new { id = projet.Id }, projet);
        }

        // PUT: api/Projet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjet(int id, Projet projet)
        {
            if (id != projet.Id)
            {
                return BadRequest();
            }

            _context.Entry(projet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Projet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet(int id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet == null)
            {
                return NotFound();
            }

            _context.Projets.Remove(projet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetExists(int id)
        {
            return _context.Projets.Any(e => e.Id == id);
        }
    }
}