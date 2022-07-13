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

        private readonly IJokeService jokeService;
        public JokeController(IJokeService jokeService) 
        {
            this.jokeService = jokeService;
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