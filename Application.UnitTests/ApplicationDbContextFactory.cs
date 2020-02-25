using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests
{
    class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        private static void SeedSampleData(ApplicationDbContext context)
        {
            var book1 = new Book()
            {
                ISBN = 24854384,
                Author = "Guy",
                Title = "Book1"
            };

            var user1 = new User()
            {
                Id = 1,
                Name = "Peter"
            };

            var book2 = new Book()
            {
                ISBN = 248543584,
                Author = "OtherGuy",
                Title = "Book2",
                LentToId = user1.Id
            };

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.LibraryUsers.Add(user1);

            context.SaveChanges();
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
