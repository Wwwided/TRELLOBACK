using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRELLOBACK.Models;
using TRELLOBACK.Context;

namespace TRELLOBACK.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListeController : ControllerBase
    {
        private readonly TrellowiContext _context;

        public ListeController(TrellowiContext context)
        {
            _context = context;
        }

        // GET: api/Liste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Liste>>> GetListes()
        {
            return await _context.Listes.ToListAsync();
        }

        // GET: api/Liste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Liste>> GetListe(int id)
        {
            var liste = await _context.Listes.FindAsync(id);

            if (liste == null)
            {
                return NotFound();
            }

            return liste;
        }

        [HttpPost]
        public async Task<ActionResult<Liste>> PostListe(Liste liste)
        {
            if (liste == null)
            {
                return BadRequest("Liste is null.");
            }
            // Charger le projet avec les listes associées
            var projet = await _context.Projets.Include(p => p.Listes).FirstOrDefaultAsync(p => p.Id == liste.ProjetId);

            if (projet == null)
            {
                return NotFound($"Project with ID {liste.ProjetId} not found.");
            }
            // Ajouter la liste au contexte et sauvegarder pour obtenir son ID
            _context.Listes.Add(liste);
            await _context.SaveChangesAsync();

            // Recharger la liste pour s'assurer que les modifications sont suivies
            var savedListe = await _context.Listes.FindAsync(liste.Id);

            // Vérifier si la liste a été sauvegardée correctement
            if (savedListe == null)
            {
                return StatusCode(500, "Liste was not saved correctly.");
            }

            // Ajouter la liste à la collection Listes du projet
            projet.Listes.Add(savedListe);

            // Sauvegarder les changements du projet
            _context.Entry(projet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Retourner l'objet créé avec le bon endpoint
            return CreatedAtAction(nameof(GetListe), new { id = liste.Id }, liste);
        }



        // PUT: api/Liste/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListe(int id, Liste liste)
        {
            if (id != liste.Id)
            {
                return BadRequest();
            }

            _context.Entry(liste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListeExists(id))
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

        // DELETE: api/Liste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListe(int id)
        {
            var liste = await _context.Listes.FindAsync(id);
            if (liste == null)
            {
                return NotFound();
            }

            _context.Listes.Remove(liste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListeExists(int id)
        {
            return _context.Listes.Any(e => e.Id == id);
        }
    }
}