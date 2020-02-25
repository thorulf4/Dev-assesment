using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(c => c.ISBN).NotNull();

            RuleFor(c => c.Author).MaximumLength(50);
            RuleFor(c => c.Author).NotEmpty();

            RuleFor(c => c.Title).MaximumLength(50);
            RuleFor(c => c.Title).NotEmpty();
        }
    }
}
