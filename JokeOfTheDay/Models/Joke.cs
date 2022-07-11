using System.ComponentModel.DataAnnotations;

namespace JokeOfTheDay.Models
{
    public class Joke
    {

        public int Id { get; set; }
        [StringLength(280)]
        public string Content { get; set; }
        public bool Inappropriate { get; set; }

        public Joke(int id, string content, bool inap) {
            Id = id;
            Content = content;
            Inappropriate = inap;
        }

        public Joke() {
            Id = 0;
            Content = "";
            Inappropriate = false;
        }
    }
}
