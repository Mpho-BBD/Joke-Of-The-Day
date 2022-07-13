using System.ComponentModel.DataAnnotations;
namespace JokeOfTheDay.Models
{
    public class JokeOfTheDayM
    {
        [Key]
        public int jokeOfTheDayId { get; set; }
        [DataType(DataType.Date)]
        public DateTime dayDate { get; set; }

        public int jokeId { get; set; }
        public Joke Joke { get; set; }

        internal JokeOfTheDayM() {}
    }
}
