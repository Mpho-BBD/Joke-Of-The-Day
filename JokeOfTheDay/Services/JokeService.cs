using JokeOfTheDay.Domain.Models;
using JokeOfTheDay.Repositories;
using AutoMapper;
using JokeOfTheDay.Models;

namespace JokeOfTheDay.Services
{
    public class JokeService : IJokeService
    {
        private readonly IJokeRepository jokeRepository;
        private readonly IMapper mapper;

        public JokeService(IJokeRepository jokeRepository, IMapper mapper)
        {
            this.jokeRepository = jokeRepository;
            this.mapper = mapper;
        }

        public JokeDTO FindJokeById(int JokeId)
        {
            Joke JokeInstance = this.jokeRepository.getJokeById(JokeId);
            return mapper.Map<JokeDTO>(JokeInstance);
        }

        public void CreateJoke(JokeDTO JokeDTO)
        {
            Joke Joke = mapper.Map<Joke>(JokeDTO);
            this.jokeRepository.createJoke(Joke);
        }

        public JokeDTO GetRandomJoke()
        {
            Joke JokeInstance = this.jokeRepository.getRandomJoke();
            return mapper.Map<JokeDTO>(JokeInstance);
        }

        public JokeDTO GetDailyJoke()
        {
            Joke JokeInstance = this.jokeRepository.getDailyJoke();
            return mapper.Map<JokeDTO>(JokeInstance);
        }
    }
}
