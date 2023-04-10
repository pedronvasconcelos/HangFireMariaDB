using HangFirePOC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangFirePOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberDrawController : ControllerBase
    {

        private readonly INumberService _numberService;

        public NumberDrawController(INumberService numberService)
        {
            _numberService = numberService;
        }

        [HttpGet(Name = "GenerateNewNumber")]
        public async Task<IActionResult> Get()
        {
            var number = await _numberService.GenerateRandomNumberDrawn();
            return Ok(number);
        }
    }
}