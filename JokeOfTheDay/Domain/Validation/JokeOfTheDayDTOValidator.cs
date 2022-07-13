using System;
using FluentValidation;
using JokeOfTheDay.Domain.Models;
using JokeOfTheDay.Domain.Validation;

namespace JokeOfTheDay.Domain.Validation
{
    public class JokeOfTheDayDTOValidator : AbstractValidator<Models.JokeOfTheDayDTO>
    {
        public JokeOfTheDayDTOValidator()
        {
            RuleFor(p => p.DayDate).NotEmpty();
            RuleFor(p => p.Joke).NotEmpty();
        }
    }
}
