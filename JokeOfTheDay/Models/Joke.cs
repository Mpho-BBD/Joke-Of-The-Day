using System.ComponentModel.DataAnnotations;

namespace JokeOfTheDay.Models
{
    public class Joke
    {

        public int Id { get; set; }
        [StringLength(280)]
        public string Content { get; set; }
        public bool Inappropriate { get; set; }
    }
}
