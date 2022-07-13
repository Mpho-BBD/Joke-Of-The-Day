using JokeOfTheDay.Domain.Models;

namespace JokeOfTheDay.Services
{
    public interface IJokeService
    {
        JokeDTO FindJokeById(int JokeId);

        void CreateJoke(JokeDTO JokeDTO);
        JokeDTO GetRandomJoke(bool isMature);
        JokeDTO GetDailyJoke();
    }
}
