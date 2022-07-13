using Microsoft.AspNetCore.Mvc;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public IActionResult Login()
        {
            _logger.LogInformation("Login requested");
            return Redirect("https://jokesapi.auth.eu-west-1.amazoncognito.com/oauth2/authorize?client_id=632uqqj15rj2j2u3mhm38qook2&response_type=code&scope=email+jokesapi%2Fjoke.read+jokesapi%2Fjoke.write+openid&redirect_uri=http://localhost:5184/session");
        }

        [HttpGet("logout")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public IActionResult Logout()
        {
            _logger.LogInformation("Logout requested");
            return Redirect("https://jokesapi.auth.eu-west-1.amazoncognito.com/logout?client_id=632uqqj15rj2j2u3mhm38qook2&logout_uri=http://localhost:4200/loggedout");
        }
    }
}
