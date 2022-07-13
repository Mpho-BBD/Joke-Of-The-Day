using System.Text.Json;

namespace JokeOfTheDay.Models
{
    public class UiHint
    {
        public bool canWriteJoke {get; set;}
        public bool canReadJoke {get; set;}
        public bool isMature {get; set;}

        public UiHint() {
            canWriteJoke = false;
            canReadJoke = false;
            isMature = false;
        }

        public void setState(HttpContext ctx) {
            canWriteJoke = ctx.User.IsInRole("Admin");
            isMature = ctx.User.IsInRole("DirtyJoker");
            canReadJoke = canWriteJoke || isMature;
        }

        public string toJson() {
            return JsonSerializer.Serialize(this);
        }
    }
}
