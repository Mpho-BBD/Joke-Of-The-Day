using JokeOfTheDay.Models;
using System.Collections.Generic;

namespace JokeOfTheDay.Repositories
{
    interface IJokeRepository
    {
        IEnumerable<Joke> GetAll();
        Joke getJokeById(int JokeId);
        void createJoke(Joke joke);
    }
}
