namespace JokeOfTheDay
{
    public static class Globals
    {
        public const string sessionCookieIdentifier = "session-cookie";
        public const string uiCookieIdentifier = "ui-cookie";

        public static CookieOptions mainCookieOptions { get { return new CookieOptions() {
                    SameSite = SameSiteMode.Strict,
                    IsEssential = true,
                    MaxAge = TimeSpan.FromMinutes(5.0)
                };
            }
        }
    }
}
