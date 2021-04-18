using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSB.api.Data;
using GSB.Shared.Models;
using GSB.Shared.RequestModels;
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

        public async Task<List<FicheFrais>> CreateFicheFrais(int id, CreateFicheModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Register model is null");
            }
            var date = DateTime.Now;

            var forfait = await _context.Forfaits.FirstOrDefaultAsync(f => f.Libelle == model.Forfait);
            var idForfait = forfait.Id;
            var montant = forfait.Montant;
            var etat = await _context.Etats.FirstOrDefaultAsync(e => e.Id == "CR");

            //var ligne = await _context.LignesFrais.Where(l => l.Mois == date.ToString("MM-yyyy")).ToListAsync();

            var fiche = new FicheFrais();
            fiche.Mois = date.ToString("MM-yyyy");
            fiche.EtatId = etat.Id;
            fiche.VisiteurId = id;
            fiche.ForfaitId = idForfait;
            fiche.Justificatifs = Convert.ToInt32(model.Justificatif);
            fiche.MontantValide = (decimal)montant * Convert.ToInt32(model.Justificatif);
            fiche.DateModification = date;

            _context.FichesFrais.Add(fiche);
            await _context.SaveChangesAsync();

            return await _context.FichesFrais.Where(f => f.Mois == fiche.Mois).ToListAsync();
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
