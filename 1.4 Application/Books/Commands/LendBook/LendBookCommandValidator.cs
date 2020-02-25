using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books.Commands.LendBook
{
    public class LendBookCommandValidator : AbstractValidator<LendBookCommand>
    {
        public LendBookCommandValidator()
        {
            RuleFor(c => c.ISBN).NotNull();

            RuleFor(c => c.UserId).NotNull();
        }
    }
}
