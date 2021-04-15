using System.Threading.Tasks;
using GSB.Shared.Models;
using GSB.Shared.RequestModels;

namespace GSB.api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<Visiteur> GetUserById(int id);
        Task<Visiteur> GetAllUser();
    }
}