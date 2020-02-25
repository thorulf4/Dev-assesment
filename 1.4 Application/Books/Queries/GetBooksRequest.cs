using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books.Queries
{
    public class GetBooksRequest : IRequest<IList<Book>> 
    {

        public class Handler : IRequestHandler<GetBooksRequest, IList<Book>>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<IList<Book>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
            {
                return await context.Books
                    .Include(book => book.LentTo)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
