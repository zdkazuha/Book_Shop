

using Book_Shop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) :base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Trilogies> Trilogies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(new[]
            {
                new Author()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Tolkien"
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Joanne",
                    LastName = "Rowling"
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "George",
                    LastName = "Martin"
                },
                new Author()
                {
                    Id = 4,
                    FirstName = "J.R.R.",
                    LastName = "Martin"
                },
                new Author()
                {
                    Id = 5,
                    FirstName = "J.K.",
                    LastName = "Rowling"
                }

    });

            modelBuilder.Entity<Book>().HasData(new[]
            {
                new Book()
    {
        Id = 1,
        Title = "The Lord of the Rings",
        Genre = "Fantasy",
        NumberOfPages = 1178,
        Year = 1954,
        Price = 20,
        Description = "Published by Allen & Unwin",
        AuthorId = 1,
        TrilogiesId = 1
    },
                new Book()
    {
        Id = 2,
        Title = "The Hobbit",
        Genre = "Fantasy",
        NumberOfPages = 310,
        Year = 1937,
        Price = 15,
        Description = "Published by Allen & Unwin",
        AuthorId = 1,
        TrilogiesId = 1
    },
                new Book()
    {
        Id = 3,
        Title = "The Silmarillion",
        Genre = "Fantasy",
        NumberOfPages = 365,
        Year = 1977,
        Price = 25,
        Description = "Published by Allen & Unwin",
        AuthorId = 1,
        TrilogiesId = 1
    },
                new Book()
    {
        Id = 4,
        Title = "Harry Potter and the Philosopher's Stone",
        Genre = "Fantasy",
        NumberOfPages = 223,
        Year = 1997,
        Price = 18,
        Description = "Published by Bloomsbury",
        AuthorId = 2,
        TrilogiesId = 2
    },
                new Book()
    {
        Id = 5,
        Title = "Harry Potter and the Chamber of Secrets",
        Genre = "Fantasy",
        NumberOfPages = 251,
        Year = 1998,
        Price = 20,
        Description = "Published by Bloomsbury",
        AuthorId = 2,
        TrilogiesId = 2
    }

            });

            modelBuilder.Entity<Trilogies>().HasData(new []
                        {
                new Trilogies()
                {
                    Id = 1,
                    NameTrilogie = "The Lord of the Rings"
                },
                new Trilogies()
                {
                    Id = 2,
                    NameTrilogie = "Harry Potter"
                },
                new Trilogies()
                {
                    Id = 3,
                    NameTrilogie = "A Song of Ice and Fire"
                },
                new Trilogies()
                {
                    Id = 4,
                    NameTrilogie = "The Chronicles of Narnia"
                },
                new Trilogies()
                {
                    Id = 5,
                    NameTrilogie = "The Hunger Games"
                }
                        });

        }
    }
}
