using Application.Books.Commands.HandInBook;
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
    public class HandInTests : CommandTest
    {

        [Fact]
        public async Task HandIn()
        {
            long ISBN = 248543584;

            var request = new HandInBookCommand()
            {
                ISBN = ISBN
            };

            var handler = new HandInBookCommand.Handler(Context);

            await handler.Handle(request, CancellationToken.None);

            Book book = Context.Books.Find(ISBN);

            book.LentToId.Should().BeNull();
        }

    }
}
