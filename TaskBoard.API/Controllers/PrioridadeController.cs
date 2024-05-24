using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskBoard.API.Interfaces;

namespace TaskBoard.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class PrioridadeController : ControllerBase
    {
        private readonly IPrioridadeService _prioridadeService;
        public PrioridadeController(IPrioridadeService prioridadeService)
        {
            _prioridadeService = prioridadeService;
        }

        [HttpGet("niveisprioridades")]
        public async Task<IActionResult> ListPrioridades()
        {
            return Ok(await _prioridadeService.ListPrioridades());
        }
    }
}
