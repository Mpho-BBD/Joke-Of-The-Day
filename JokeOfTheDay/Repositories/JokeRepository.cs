using JokeOfTheDay.Models;
using System.Linq.Expressions;

namespace JokeOfTheDay.Repositories
{
    public class JokeRepository
    {
        private readonly JokeContext context;

        public JokeRepository(JokeContext context)
        {
            this.context = context;
        }
        public Joke getById(int JokeId)
        {
            return context.Jokes.Find(JokeId);
        }

        public void createJoke(Joke joke)
        {
            this.context.Add(joke);
            this.context.SaveChanges();
        }
    }
}
