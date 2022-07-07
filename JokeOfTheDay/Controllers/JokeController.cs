using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("joke/[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;

        public JokeController(ILogger<JokeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Joke")]
        public Joke Get()
        {
            return new Joke();
        }
    }
}