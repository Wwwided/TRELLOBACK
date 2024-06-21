using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRELLOBACK.Models;
using TRELLOBACK.Context;
using TRELLOBACK.DAO;

namespace TRELLOBACK.Controllers
{
    [Route("[controller]")]
    [ApiController]
        public class ProjetController : ControllerBase
    {
        private readonly ProjetDAO _projetDAO;

        public ProjetController(ProjetDAO projetDAO)
        {
            _projetDAO = projetDAO;
        }
      
/*     public class ProjetController : ControllerBase
    {
        private readonly TrellowiContext _context;

        public ProjetController(TrellowiContext context)
        {
            _context = context;
        } */
  
        // GET: api/Projet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetDTOListesDTO>>> GetProjets()
        {
            return Ok(await _projetDAO.GetProjets());

        }
/*         public async Task<ActionResult<IEnumerable<ProjetDTOListesDTO>>> GetProjets()
        {
            var projets = await _context.Projets
                                    .Include(p => p.Listes)
                                    .Select(p => new ProjetDTOListesDTO
                                    {
                                        Id = p.Id,
                                        TitreProjet = p.TitreProjet,
                                        Listes = p.Listes.Select(l => new ListeDTO
                                        {
                                            Id = l.Id,
                                            TitreListe = l.TitreListe,
                                            ProjetId = l.ProjetId
                                        }).ToList()
                                    })
                                    .ToListAsync();

        return Ok(projets);
        } */
        

        // GET: api/Projet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetDTOListesDTO>> GetProjet(int id)
        {
            Projet projet = await _projetDAO.GetProjet(id);
            if(projet == null)
            {
                return NotFound();
            }

            return Ok(projet.ToProjetDTO());
        }
/*         public async Task<ActionResult<Projet>> GetProjet(int id)
        {
            var projet = await _context.Projets.Include(p => p.Listes).FirstOrDefaultAsync(p => p.Id == id);

            if (projet == null)
            {
                return NotFound();
            }

            return projet;
            } */
        

        // POST: api/Projet
        [HttpPost]
        public async Task<ActionResult<Projet>> PostProjet([FromBody] ProjetDTO projetDTO)
        {
            Projet projet = new Projet 
            {
                Id = projetDTO.Id,
                TitreProjet = projetDTO.TitreProjet
            };

            await _projetDAO.AddProjet(projet);

            return Ok(projet);
        }

/*         public async Task<ActionResult<Projet>> PostProjet(Projet projet)
        {
            _context.Projets.Add(projet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjet), new { id = projet.Id }, projet);
        } */

        // PUT: api/Projet/5
        [HttpPut("{id}")]
            public async Task<IActionResult> PutProjet(int id, Projet projet)
        {
            if (id != projet.Id)
            {
                return BadRequest();
            }

            await _projetDAO.UpdateProjet(id,projet);
            return Ok();
        }


/*         public async Task<IActionResult> PutProjet(int id, Projet projet)
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
        } */

        // DELETE: api/Projet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet(int id)
        {
            var statut = await _projetDAO.RemoveProjet(id);

            if (statut = false)
            {
                return NotFound();
            }

            return Ok();
        }


        /* public async Task<IActionResult> DeleteProjet(int id)
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
        } */
    }
}