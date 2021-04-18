using System.Collections.Generic;
using System.Threading.Tasks;
using GSB.Shared.Models;
using GSB.Shared.RequestModels;

namespace GSB.api.Repositories.FraisRepository
{
    public interface IFraisRepository
    {
        Task<List<FicheFrais>> CreateFicheFrais(int id, CreateFicheModel model);
        Task<List<LigneFrais>> GetAllFrais(int idVisiteur);
        Task<List<LigneFrais>> GetFicheByMonth(int idVisiteur, string date);
        Task<List<FicheFrais>> GetFichesByStatus(string idEtat);
    }
}