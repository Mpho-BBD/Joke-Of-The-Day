using JokeOfTheDay.Models;

namespace JokeOfTheDay.Services
{
    public class CookieService : ICookieService
    {
        private readonly string sessionCookieIdentifier = "session-cookie";
        private readonly string uiCookieIdentifier = "ui-cookie";

        private static CookieOptions mainCookieOptions { get { return new CookieOptions() {
                    SameSite = SameSiteMode.Strict,
                    IsEssential = true,
                    MaxAge = TimeSpan.FromMinutes(5.0)
                };
            }
        }

        public CookieService() {}

        public void SetSessionCookie(HttpResponse response) {
            response.Cookies.Delete(sessionCookieIdentifier);
            response.Cookies.Append(sessionCookieIdentifier, "1941446516515315665", mainCookieOptions);
        }

        public void SetUiCookie(HttpResponse response, UiHint hint) {
            response.Cookies.Delete(uiCookieIdentifier);
            response.Cookies.Append(uiCookieIdentifier, hint.toJson(), mainCookieOptions);
        }

        public string GetSession(HttpRequest request) {
            string? session;
            if (request.Cookies.TryGetValue(sessionCookieIdentifier, out session)) {
                return session;
            }
            return "";
        }
    }
}
