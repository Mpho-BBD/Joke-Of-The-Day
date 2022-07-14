using JokeOfTheDay.Models;

namespace JokeOfTheDay.Services
{
    public interface ICookieService
    {
        void SetSessionCookie(HttpResponse response, string session_cookie);
        void SetUiCookie(HttpResponse response, UiHint hint);
        string GetSessionCookie(HttpRequest request);
    }
}
