using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;
using Microsoft.Extensions.Options;
using JokeOfTheDay.Data;
using JokeOfTheDay.Services;
using JokeOfTheDay.Domain.Models;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("/api/v1/jokes")]
    public class JokeController : ControllerBase
    {
        private readonly IJokeService _jokeService;
        private readonly ILogger<JokeController> _logger;
        public JokeController(IJokeService jokeService, ILogger<JokeController> logger) 
        {
            this._jokeService = jokeService;
            this._logger = logger;
        }

        [HttpGet("daily")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JokeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDailyJoke()
        {
            _logger.LogInformation("Daily joke request");
            JokeDTO JokeObject = this._jokeService.GetDailyJoke();
            if(JokeObject == null)
            {
                return NotFound();
            }
            return new OkObjectResult(JokeObject);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JokeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRandomJoke()
        {
            _logger.LogInformation("Random joke request from {}", "x");
            JokeDTO JokeObject = this._jokeService.GetRandomJoke();
            if(JokeObject == null)
            {
                return NotFound();
            }
            return new OkObjectResult(JokeObject);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JokeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJoke([FromBody] JokeDTO JokeDTO)
        {
            try
            {
                this._jokeService.CreateJoke(JokeDTO);
                return new ObjectResult("Created Joke");
            }
            catch(ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}
