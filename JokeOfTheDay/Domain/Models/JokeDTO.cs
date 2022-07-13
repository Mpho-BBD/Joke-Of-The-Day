namespace JokeOfTheDay.Domain.Models
{
    public class JokeDTO
    {
        public int Id { get; set; } 

        public string Content { get; set; }

        public bool InappInappropriate { get; set; }
    }
}
