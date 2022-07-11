using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("joke/[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;
        private readonly IConfigSettings _configSettings;

        public JokeController(ILogger<JokeController> logger, IConfigSettings configSettings)
        {
            _logger = logger;
            _configSettings = configSettings;
        }

        [HttpGet(Name = "Joke")]
        public Joke Get()
        {
            return new Joke();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string GetSecret()
        {
            var result = "key 1 - " + _configSettings.Port + " : Key 2 - " + _configSettings.Username;
            return result;
        }
    }
}