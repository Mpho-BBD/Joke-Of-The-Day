using JokeOfTheDay.Models;
using Microsoft.EntityFrameworkCore;


namespace JokeOfTheDay.Data
{
    public class JokeContext : DbContext
    {
        public JokeContext(DbContextOptions<JokeContext> options) : base(options)
        {
        }

        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Models.JokeOfTheDay> JokesOfTheDay { get; set; }
    }
}
