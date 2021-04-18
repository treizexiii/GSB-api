using System.Runtime.InteropServices;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using GSB.api.Repositories.FraisRepository;
using GSB.Shared.RequestModels;
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
        public async Task<IActionResult> GetAllFrais()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _fraisRepository.GetAllFrais(Convert.ToInt32(userId)));
        }

        [HttpPost("CreateFiche")]
        public async Task<IActionResult> CreateFicheFrais([FromBody] CreateFicheModel model)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            try
            {
                return Ok(await _fraisRepository.CreateFicheFrais(userId, model));
            }
            catch
            {
                return Ok("Error");
            }
        }

        [HttpGet("/{date}")]
        public async Task<IActionResult> GetFraisByMonth(int id, string date)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _fraisRepository.GetFicheByMonth(Convert.ToInt32(userId), date));
        }
    }
}
