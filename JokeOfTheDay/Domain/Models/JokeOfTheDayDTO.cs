using JokeOfTheDay.Models;
using System.ComponentModel.DataAnnotations;

namespace JokeOfTheDay.Domain.Models
{
    public class JokeOfTheDayDTO
    {
        public int Id { get; set; }
        public DateTime DayDate { get; set; }

        public JokeDTO Joke { get; set; }

        public JokeOfTheDayDTO(JokeOfTheDayM jod) {
            Id = jod.jokeOfTheDayId;
            DayDate = jod.dayDate;
            Joke = new JokeDTO(jod.Joke);
        }
    }
}
