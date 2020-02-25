using Application.Books.Commands.CreateBook;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Books
{
    public class CreateBooksTest : CommandTest
    {
        [Fact]
        public async Task ISBNReturn()
        {
            long ISBN = 48463578;

            var command = new CreateBookCommand()
            {
                ISBN = 48463578,
                Author = "some guy",
                Title = "awesome book"
            };

            var handler = new CreateBookCommand.Handler(Context);

            long newISBN = await handler.Handle(command, CancellationToken.None);

            newISBN.Should().Be(ISBN);
        }

        [Fact]
        public async Task BookCount()
        {
            long ISBN = 48463578;

            var command = new CreateBookCommand()
            {
                ISBN = ISBN,
                Author = "some guy",
                Title = "awesome book"
            };

            var handler = new CreateBookCommand.Handler(Context);

            await handler.Handle(command, CancellationToken.None);

            var books = await Context.Books.ToListAsync();

            books.Count.Should().Be(3);
        }
    }
}
