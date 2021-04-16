using System;
using System.Security.Claims;
using System.Threading.Tasks;
using GSB.api.Repositories.FraisRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GSB.api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FraisController : ControllerBase
    {
        private readonly IFraisRepository _fraisRepository;

        public FraisController(IFraisRepository fraisRepository)
        {
            _fraisRepository = fraisRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFrais() {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _fraisRepository.GetAllFrais(Convert.ToInt32(userId)));
        }

        [HttpGet("{id}/{date}")]
        public async Task<IActionResult> GetFraisByMonth(int id, string date) {
            return Ok(await _fraisRepository.GetFicheByMonth(id, date));
        }
    }
}