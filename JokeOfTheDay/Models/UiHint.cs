using System.Text.Json;

namespace JokeOfTheDay.Models
{
    public class UiHint
    {
        public bool canWriteJoke {get; set;}
        public bool canReadJoke {get;set;}
        public bool isMature {get;set;}

        public UiHint() {
            canWriteJoke = false;
            canReadJoke = false;
            isMature = false;
        }

        public void setState() {
            canWriteJoke = true;
            canReadJoke = true;
            isMature = true;
        }

        public string toJson() {
            return JsonSerializer.Serialize(this);
        }
    }
}
