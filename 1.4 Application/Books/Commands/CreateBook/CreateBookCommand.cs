using Application.Interfaces;
using MediatR;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<long>
    {
        public long ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public class Handler : IRequestHandler<CreateBookCommand, long>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                await context.Books.AddAsync(new Book()
                {
                    ISBN = request.ISBN,
                    Title = request.Title,
                    Author = request.Author
                });

                await context.SaveChangesAsync(cancellationToken);

                return request.ISBN;
            }
        }
    }
}
