using Application.Interfaces;
using MediatR;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class CreateUserRequest : IRequest<int>
    {
        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateUserRequest, int>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateUserRequest request, CancellationToken cancellationToken)
            {
                User user = new User()
                {
                    Name = request.Name
                };

                await context.LibraryUsers.AddAsync(user);

                await context.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }
}
