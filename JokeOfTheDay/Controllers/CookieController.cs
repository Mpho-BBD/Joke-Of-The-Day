using Microsoft.AspNetCore.Mvc;
using JokeOfTheDay.Models;

namespace JokeOfTheDay.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CookieController : ControllerBase
    {
        private readonly ILogger<CookieController> _logger;

        public CookieController(ILogger<CookieController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Validate()
        {
            _logger.LogInformation("Validation request from {}", "x");
            UiHint hint = new UiHint();
            hint.setState();
            SetUiCookie(hint);

            if (true)
            {
                return Ok();   
            }
            return Unauthorized();
        }


        [HttpGet(Name = "Session")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Session(string code)
        {
            _logger.LogInformation("Session requested for {}", code);
            UiHint hint = new UiHint();
            hint.setState();
            SetUiCookie(hint);
            return Ok();
        }

        private void SetUiCookie(UiHint hint) {
            HttpContext.Response.Cookies.Delete(Globals.uiCookieIdentifier);
            HttpContext.Response.Cookies.Append(Globals.uiCookieIdentifier, hint.toJson(), Globals.mainCookieOptions);
        }

        private void SetSessionCookie() {
            HttpContext.Response.Cookies.Delete(Globals.sessionCookieIdentifier);
            HttpContext.Response.Cookies.Append(Globals.sessionCookieIdentifier, "1941446516515315665", Globals.mainCookieOptions);
        }
    }
}
