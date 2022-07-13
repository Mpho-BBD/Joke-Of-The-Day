using JokeOfTheDay.Models;
using System.Collections.Generic;

namespace JokeOfTheDay.Repositories
{
    public interface IJokeRepository
    {
        Joke getJokeById(int JokeId);
        void createJoke(Joke _joke);
        Joke getRandomJoke();
        Joke getDailyJoke();
    }
}
