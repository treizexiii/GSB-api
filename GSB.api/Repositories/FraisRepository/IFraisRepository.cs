using System.Collections.Generic;
using System.Threading.Tasks;
using GSB.Shared.Models;

namespace GSB.api.Repositories.FraisRepository
{
    public interface IFraisRepository
    {
        Task<List<LigneFrais>> GetAllFrais(int idVisiteur);
        Task<List<LigneFrais>> GetFicheByMonth(int idVisiteur, string date);
        Task<List<FicheFrais>> GetFichesByStatus(string idEtat);
    }
}