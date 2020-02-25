using Application.Interfaces;
using MediatR;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books.Commands.HandInBook
{
    public class HandInBookCommand : IRequest
    {
        public long ISBN { get; set; }

        public class Handler : IRequestHandler<HandInBookCommand>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(HandInBookCommand request, CancellationToken cancellationToken)
            {
                Book book = await context.Books.FindAsync(request.ISBN);

                book.LentToId = null;

                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
