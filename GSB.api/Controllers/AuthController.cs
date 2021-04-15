using System.Threading.Tasks;
using GSB.api.Data;
using GSB.api.Repositories.UserRepository;
using GSB.Shared.Models;
using GSB.Shared.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GSB.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<GsbContext> _userManager;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(int id) {
            return Ok(await _userRepository.GetUserById(id));
        }
    }
}
