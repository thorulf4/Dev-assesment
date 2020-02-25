using Application.Interfaces;
using MediatR;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books.Commands.LendBook
{
    public class LendBookCommand : IRequest
    {
        public long ISBN { get; set; }
        public int UserId { get; set; }

        public class Handler : IRequestHandler<LendBookCommand>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(LendBookCommand request, CancellationToken cancellationToken)
            {
                Book book = await context.Books.FindAsync(request.ISBN);

                book.LentToId = request.UserId;

                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
