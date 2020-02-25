using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books.Commands.HandInBook
{
    public class HandInBookCommandValidator : AbstractValidator<HandInBookCommand>
    {
        public HandInBookCommandValidator()
        {
            RuleFor(c => c.ISBN).NotNull();
        }
    }
}
