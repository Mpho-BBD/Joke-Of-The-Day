using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;

        public JokeController(ILogger<JokeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Joke")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Joke))]
        public IActionResult  Get()
        {
            return Ok(new Joke());
        }
    }
}