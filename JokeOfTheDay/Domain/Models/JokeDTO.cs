using JokeOfTheDay.Models;
namespace JokeOfTheDay.Domain.Models
{
    public class JokeDTO
    {
        public int Id { get; set; } 

        public string Content { get; set; }

        public bool Inappropriate { get; set; }

        public JokeDTO() {}

        public JokeDTO(Joke j) {
            Id = j.jokeId;
            Content = j.content;
            Inappropriate = j.inappropriate;
        }
    }
}
