using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSB.api.Data;
using GSB.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GSB.api.Repositories.FraisRepository
{
    public class FraisRepository : IFraisRepository
    {
        private readonly GsbContext _context;

        public FraisRepository(GsbContext context)
        {
            _context = context;
        }
        public async Task<List<LigneFrais>> GetAllFrais(int idVisiteur)
        {
            return await _context.LignesFrais.Where(x => x.VisiteurId == idVisiteur).ToListAsync();
        }

        public async Task<List<LigneFrais>> GetFicheByMonth(int idVisiteur, string date)
        {
            return await _context.LignesFrais.Where(x => x.VisiteurId == idVisiteur && x.Mois.ToString() == date).ToListAsync();
        }

        public async Task<List<FicheFrais>> GetFichesByStatus(string idEtat)
        {
            return await _context.FichesFrais.Where(x => x.EtatId == idEtat).ToListAsync();
        }
    }
}
