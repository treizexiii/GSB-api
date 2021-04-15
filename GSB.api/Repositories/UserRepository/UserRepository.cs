using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using GSB.api.Areas.Identity.Data;
using GSB.api.Data;
using GSB.Shared.Models;
using GSB.Shared.RequestModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GSB.api.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly GsbContext _context;
        private readonly UserManager<GSBapiUser> _userManager;
        private readonly SignInManager<GSBapiUser> _signInManager;

        public UserRepository(GsbContext context,
            UserManager<GSBapiUser> userManager,
            SignInManager<GSBapiUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<Visiteur> GetAllUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Visiteur> GetUserById(int id)
        {
            return await _context.Visiteurs.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<UserManagerResponse> GetToken([FromBody] LoginRequest loginRequest) {
            var user = await _userManager.FindByNameAsync(loginRequest.Login);

            if (user == null) {
                return new UserManagerResponse {
                    Message = "Le login ne correspond à aucun utilisateur",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!result) {
                return new UserManagerResponse {
                    Message = "Mot de passe invalid",
                    IsSuccess = false
                };
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.VisiteurId.ToString()),
                new Claim("Prenom", user.Visiteur.Prenom),
                new Claim("Nom", user.Visiteur.Nom)
            };
        }
    }
}