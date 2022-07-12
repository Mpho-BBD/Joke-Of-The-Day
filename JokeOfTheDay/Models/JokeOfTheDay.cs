using System.ComponentModel.DataAnnotations;

namespace JokeOfTheDay.Models
{
    public class JokeOfTheDay
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int JokeID { get; set; }

        public virtual Joke Joke { get; set; }
    }
}