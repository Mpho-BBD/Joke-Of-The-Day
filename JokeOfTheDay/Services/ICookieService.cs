using JokeOfTheDay.Models;

namespace JokeOfTheDay.Services
{
    public interface ICookieService
    {
        void SetSessionCookie(HttpResponse response);
        void SetUiCookie(HttpResponse response, UiHint hint);
    }
}
