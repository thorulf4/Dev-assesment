using Application.Users.Queries;
using FluentAssertions;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Users
{
    public class GetUsersTests : CommandTest
    {

        [Fact]
        public async Task GetUsers()
        {
            var request = new GetUsersRequest();

            var handler = new GetUsersRequest.Handler(Context);

            IList<User> users = await handler.Handle(request, CancellationToken.None);

            users.Count.Should().Be(1);
        }

    }
}
