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

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(int id) {
            return Ok(await _userRepository.GetUserById(id));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model) {
            return Ok(await _userRepository.RegisterAsync(model));
        }

        [HttpPost("getToken")]
        [ProducesResponseType(200, Type = typeof(UserManagerResponse))]
        [ProducesResponseType(400, Type = typeof(UserManagerResponse))]
        public async Task<ActionResult> GetToken([FromBody] LoginRequest loginRequest) {
            return Ok(await _userRepository.LoginAsync(loginRequest));
        }
    }
}
