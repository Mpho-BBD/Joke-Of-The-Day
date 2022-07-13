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
        private Joke _joke;
        public Joke Joke => _joke;

        private readonly IJokeService jokeService;
        public JokeController(IJokeService jokeService) 
        {
            this.jokeService = jokeService;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyJoke()
        {
            JokeDTO JokeObject = this.jokeService.GetDailyJoke();
            if(JokeObject == null)
            {
                return NotFound();
            }
            return new OkObjectResult(JokeObject);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetRandomJoke()
        {
            
            JokeDTO JokeObject = this.jokeService.GetRandomJoke();
            if(JokeObject == null)
            {
                return NotFound();
            }
            return new OkObjectResult(JokeObject);
        }

        [HttpPost]
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