using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRELLOBACK.Context;
using TRELLOBACK.Models;

namespace TRELLOBACK.DAO;

public class ProjetDAO
{
    private readonly TrellowiContext _context;
    public ProjetDAO(TrellowiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjetDTOListesDTO>> GetProjets()
    {
        return await _context.Projets
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

    }

        public async Task<Projet> GetProjet(int id)
    {
        return await _context.Projets.Include(p => p.Listes).FirstOrDefaultAsync(p => p.Id == id);

    }
        public async Task<Projet> AddProjet(Projet projet)
    {
        _context.Projets.Add(projet);
        await _context.SaveChangesAsync();
        return projet;
    }

        public async Task<Projet> UpdateProjet(int id, Projet projet)
    {        
        _context.Entry(projet).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        return projet;
    }

        public async Task<bool> RemoveProjet(int id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet == null)
            {
                return false;
            }

            _context.Projets.Remove(projet);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProjetExists(int id)
        {
            return _context.Projets.Any(e => e.Id == id);
        }
}