using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRELLOBACK.Models;
using TRELLOBACK.Context;

namespace TRELLOBACK.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarteController : ControllerBase
    {
        private readonly TrellowiContext _context;
        public CarteController(TrellowiContext context)
        {
            _context = context;
        }
   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carte>>> GetCartes()
        {
            System.Console.WriteLine("lol");
            return await _context.Cartes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carte>> GetCarte(int id)
        {
            var carte = await _context.Cartes.FindAsync(id);

            if (carte == null)
            {
                return NotFound();
            }

            return carte;
        }

        [HttpPost]
        public async Task<ActionResult<Carte>> PostCarte(Carte carte)
        {
            _context.Cartes.Add(carte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarte), carte);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarte(int id, Carte carte)
        {
            if (id != carte.Id)
            {
                return BadRequest();
            }

            _context.Entry(carte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarteExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarte(int id)
        {
            var carte = await _context.Cartes.FindAsync(id);
            if (carte == null)
            {
                return NotFound();
            }

            _context.Cartes.Remove(carte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarteExists(int id)
        {
            return _context.Cartes.Any(e => e.Id == id);
        }
    }
}