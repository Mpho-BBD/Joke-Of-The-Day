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

        public Joke getRandomJoke()
        {   
            Random rand = new Random();
            int toSkip = rand.Next(1, context.Joke.Count());
            
            return this.context.Joke.Skip(toSkip).Take(1).First();
        }

        public Joke getDailyJoke()
        {   
            var Today = DateTime.Today;
            var dailyJoke = this.context.JokeOfTheDay.Where(jd => jd.dayDate == Today).FirstOrDefault();
            if (dailyJoke is null)
            {
                var newDailyJoke = new JokeOfTheDayM();
                newDailyJoke.dayDate = Today;
                var randJoke = getRandomJoke();
                newDailyJoke.jokeId = randJoke.jokeId;
                context.Add(newDailyJoke);
                return randJoke;
            }
            return getJokeById(dailyJoke.jokeId); //dailyJoke.Joke (after data relationship is set up)
        }


    }
}
