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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JokeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JokeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JokeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateJoke([FromBody] JokeDTO JokeDTO)
        {
            //WHEN AUTH IS READY
            string? session;
            if (HttpContext.Request.Cookies.TryGetValue(Globals.sessionCookieIdentifier, out session)) {

            }
            //------------------

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
