using System.Text;
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
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace GSB.api.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly GsbContext _context;
        private readonly UserManager<GSBapiUser> _userManager;
        private readonly SignInManager<GSBapiUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserRepository(GsbContext context,
            UserManager<GSBapiUser> userManager,
            SignInManager<GSBapiUser> signInManager,
            IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public Task<Visiteur> GetAllUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<GSBapiUser> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Visiteur).Include(u => u.Role).FirstOrDefaultAsync(u => u.VisiteurId == id);
        }

        public async Task<UserManagerResponse> RegisterAsync(RegisterModel model) {
            if (model == null) {
                throw new NullReferenceException("Register model is null");
            }

            if (model.Password != model.ConfirmPassword) {
                return new UserManagerResponse {
                    Message = "Les mots de passe ne corresponde pas",
                    IsSuccess = false
                };
            }

            var identityUser = new GSBapiUser {
                VisiteurId = 1,
                UserName = model.UserName,
                RoleId = 2
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded) {
                return new UserManagerResponse {
                    Message = "L'utilisateur a été créer avec succès",
                    IsSuccess = true
                };
            }

            return new UserManagerResponse {
                Message = "L'utilisateur n'a pas été créer",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> LoginAsync(LoginRequest loginRequest) {
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.VisiteurId.ToString()),
                    new Claim("roleId", user.RoleId.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                Issuer = _configuration["AuthSettings:Issuer"],
                Audience = _configuration["AuthSettings:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenAsString = tokenHandler.WriteToken(token);

            return new UserManagerResponse {
                UserInfo = tokenDescriptor.Subject.Claims.ToDictionary(c => c.Type, c => c.Value),
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = tokenDescriptor.Expires
            };
        }
    }
}
