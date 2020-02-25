using Application.Books.Commands.LendBook;
using FluentAssertions;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Books
{
    public class LendBookTests : CommandTest
    {
        [Fact]
        public async Task LendBook()
        {
            long book1ISBN = 24854384;
            var command = new LendBookCommand()
            {
                ISBN = book1ISBN,
                UserId = 1
            };

            var handler = new LendBookCommand.Handler(Context);

            await handler.Handle(command, CancellationToken.None);

            Book book = Context.Books.Find(book1ISBN);

            book.LentToId.Should().Be(1);
        }
    }
}
