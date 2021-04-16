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

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFrais(int id) {
            return Ok(await _fraisRepository.GetAllFrais(id));
        }

        [HttpGet("{id}/{date}")]
        public async Task<IActionResult> GetFraisByMonth(int id, string date) {
            return Ok(await _fraisRepository.GetFicheByMonth(id, date));
        }
    }
}