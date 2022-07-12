﻿using JokeOfTheDay.Domain.Models;

namespace JokeOfTheDay.Services
{
    public interface IJokeService
    {
        JokeDTO FindJokeById(int JokeId);

        void CreateJoke(JokeDTO Joke);
    }
}
