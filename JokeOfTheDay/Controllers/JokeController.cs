using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;
using Microsoft.Extensions.Options;
using JokeOfTheDay.Data;
using JokeOfTheDay.Services;
using JokeOfTheDay.Domain.Models;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private Joke _joke;
        public Joke Joke => _joke;

        private readonly ILogger<JokeController> _logger;
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        private readonly IJokeService jokeService;

        public JokeController(ILogger<JokeController> logger, IOptions<DatabaseSettings> databaseSettings, IJokeService jokeService) 
        {
            _logger = logger;
            _databaseSettings = databaseSettings;
            this.jokeService = jokeService;
        }

        [HttpGet("settings")]
        public IActionResult GetSettings()
        {
            var settings = _databaseSettings.Value;
            return Ok(settings);
        }

        [HttpGet("GetJoke/{id}")]
        public async Task<IActionResult> GetJoke(int id)
        {
            JokeDTO JokeObject = this.jokeService.FindJokeById(id);
            if(JokeObject == null)
            {
                return NotFound();
            }
            return new ObjectResult(JokeObject);
        }

        [HttpPost("CreateJoke")]
        public async Task<IActionResult> CreateJoke([FromBody] JokeDTO JokeDTO)
        {
            try
            {
                this.jokeService.CreateJoke(JokeDTO);
                return new ObjectResult("Created Joke");
            }
            catch(ArgumentException ex)
            {
                return BadRequest();
            }
        }
    }
}