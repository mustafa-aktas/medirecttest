using LightsOut_Api_Mustafa_Aktas.DTO;
using LightsOut_Api_Mustafa_Aktas.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LightsOut_Api_Mustafa_Aktas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("board")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetBoardInfAsync()
        {
            var c = await _service.GetBoardData();
            return Ok(c);
        }
    }
}