using System.ComponentModel.DataAnnotations;
using JokeOfTheDay.Domain.Models;
namespace JokeOfTheDay.Models
{
    public class Joke
    {
        [Key]
        public int jokeId { get; set; }
         [StringLength(280)]
        public string content { get; set; }
        public bool inappropriate { get; set; }
        public List<JokeOfTheDayM> JokesOfTheDays { get; set; }

        internal Joke() {}

        public Joke(JokeDTO dto) {
            jokeId = dto.Id;
            content = dto.Content;
            inappropriate = dto.Inappropriate;
        }
    }
}
