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
            string? session;
            if (HttpContext.Request.Cookies.TryGetValue(Globals.sessionCookieIdentifier, out session)) {
                _logger.LogInformation(session);
            }
            return Ok(new Joke());
        }
    }
}
