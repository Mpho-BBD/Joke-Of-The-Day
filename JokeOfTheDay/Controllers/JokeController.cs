using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;
using Microsoft.Extensions.Options;
using JokeOfTheDay.Data;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;
        private readonly IOptions<DatabaseSettings> _databaseSettings;

        public JokeController(ILogger<JokeController> logger, IOptions<DatabaseSettings> databaseSettings) 
        {
            _logger = logger;
            _databaseSettings = databaseSettings;
        }

        [HttpGet(Name = "Joke")]
        public Joke Get()
        {
            return new Joke();
        }
    }
}