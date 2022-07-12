using System.ComponentModel.DataAnnotations;

namespace JokeOfTheDay.Models
{
    public class Joke_of_the_day
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int JokeID { get; set; }

        public virtual Joke Joke { get; set; }
    }
}