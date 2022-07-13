using System;
using FluentValidation;
using JokeOfTheDay.Domain.Models;
using JokeOfTheDay.Domain.Validation;

namespace JokeOfTheDay.Domain.Validation
{
    public class JokeDTOValidator : AbstractValidator<JokeDTO>
    {
        public JokeDTOValidator()
        {
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.Inappropriate).NotEmpty();
        }
    }
}
