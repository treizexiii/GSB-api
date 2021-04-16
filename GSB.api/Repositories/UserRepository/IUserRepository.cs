using System.Threading.Tasks;
using GSB.api.Areas.Identity.Data;
using GSB.Shared.Models;
using GSB.Shared.RequestModels;

namespace GSB.api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<Visiteur> GetAllUser();
        Task<GSBapiUser> GetUserById(int id);
        Task<UserManagerResponse> RegisterAsync(RegisterModel model);
        Task<UserManagerResponse> LoginAsync(LoginRequest loginRequest);
    }
}