using Application.Books.Queries;
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
    public class GetBooksTests : CommandTest
    {

        [Fact]
        public async Task CheckBookCount()
        {
            var request = new GetBooksRequest();

            var handler = new GetBooksRequest.Handler(Context);
            IList<Book> books = await handler.Handle(request, CancellationToken.None);

            books.Count.Should().Be(2);
        }

    }
}
