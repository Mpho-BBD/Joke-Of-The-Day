using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;
using Microsoft.Extensions.Options;
using JokeOfTheDay.Data;
using JokeOfTheDay.Services;
using JokeOfTheDay.Domain.Models;
using JokeOfTheDay.Repositories;

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
        private JokeContext context;

        public JokeController(ILogger<JokeController> logger, IOptions<DatabaseSettings> databaseSettings, IJokeService jokeService,JokeContext context) 
        {
            _logger = logger;
            _databaseSettings = databaseSettings;
            this.jokeService = jokeService;
            this.context = context;
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

        [HttpGet("GetDailyJoke")]
        public async Task<IActionResult> GetDailyJoke()
        {
            JokeRepository dailyOB = new JokeRepository(context);
            DateTime date= DateTime.Now;
            if ( dailyOB== null )
            {
                return NotFound();
            }
            var dJoke = context.Find<Joke_of_the_day>(date.Date);
            if (dJoke == null)
            {
                return NotFound();
            }

            return new ObjectResult(dJoke);
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