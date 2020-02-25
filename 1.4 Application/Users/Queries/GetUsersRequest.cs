using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUsersRequest : IRequest<IList<User>>
    {

        public class Handler : IRequestHandler<GetUsersRequest, IList<User>>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<IList<User>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
            {
                return await context.LibraryUsers.ToListAsync(cancellationToken);
            }
        }
    }
}
