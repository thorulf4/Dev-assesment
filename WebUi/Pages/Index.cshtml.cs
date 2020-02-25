using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Model.Entities;
using MediatR;
using Application.Books.Queries;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Application.Books.Commands.HandInBook;
using Application.Books.Commands.LendBook;

namespace WebUi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private UserManager<ApplicationUser> _userManager;

        public IndexModel(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            this._mediator = mediator;
            _userManager = userManager;
        }

        public IList<Book> Books { get;set; }
        public int? UserId { get; set; }

        public async Task OnGetAsync()
        {
            Books = await _mediator.Send(new GetBooksRequest());

            UserId = (await _userManager.GetUserAsync(User))?.UserId;
        }

        public async Task<IActionResult> OnPostBorrowAsync(int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            await _mediator.Send(new LendBookCommand()
            {
                ISBN = id,
                UserId = user.UserId
            });

            return Redirect("~/"); ;
        }

        public async Task<IActionResult> OnPostHandInAsync(int id)
        {
            await _mediator.Send(new HandInBookCommand()
            {
                ISBN = id
            });

            return Redirect("~/"); ;
        }
    }
}
