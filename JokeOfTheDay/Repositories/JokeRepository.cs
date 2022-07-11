using JokeOfTheDay.Models;
using JokeOfTheDay.Data;
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

        public IEnumerable<Joke> GetAll()
        {
            return context.Set<Joke>().ToList();
        }

        public Joke getById(int JokeId)
        {
            return context.Set<Joke>().Find(JokeId);
        }

        public void createJoke(Joke joke)
        {
            this.context.Add(joke);
        }
    }
}
