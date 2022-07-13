using JokeOfTheDay.Models;
using JokeOfTheDay.Data;
using System.Linq.Expressions;

namespace JokeOfTheDay.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        private JokeContext context;

        public JokeRepository(JokeContext context)
        {
            this.context = context;
        }

        public Joke getJokeById(int JokeId)
        {
            return this.context.Find<Joke>(JokeId);
        }

        public void createJoke(Joke _joke)
        {
            this.context.Add(_joke);
            this.context.SaveChanges();
        }
    }
}
