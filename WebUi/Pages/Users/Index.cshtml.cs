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
using Application.Users.Queries;

namespace WebUi.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IMediator mediator;

        public IndexModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await mediator.Send(new GetUsersRequest());
        }
    }
}
