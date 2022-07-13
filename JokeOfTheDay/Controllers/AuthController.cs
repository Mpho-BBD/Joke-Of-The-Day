using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Services;
using JokeOfTheDay.Models;
using Microsoft.AspNetCore.Authorization;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class CookieController : ControllerBase
    {
        private readonly ILogger<CookieController> _logger;
        private readonly ICookieService _cookieService;

        public CookieController(ILogger<CookieController> logger, ICookieService cookieService)
        {
            _logger = logger;
            _cookieService = cookieService;
        }

        [Authorize]
        [HttpGet("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Validate()
        {
            _logger.LogInformation("Validation request from {}", "x");
            UiHint hint = new UiHint();
            hint.setState();
            _cookieService.SetUiCookie(HttpContext.Response, hint);

            if (true)
            {
                return Ok("OK");
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("session")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Session(string code)
        {
            _logger.LogInformation("Session requested for {}", code);
            UiHint hint = new UiHint();
            hint.setState();
            _cookieService.SetUiCookie(HttpContext.Response, hint);
            return Redirect("/dashboard");
        }
    }
}
