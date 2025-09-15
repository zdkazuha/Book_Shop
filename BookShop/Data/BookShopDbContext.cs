

using Book_Shop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) :base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Trilogies> Trilogies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = 1, GenreName = "Fantasy" },
                new Genre() { Id = 2, GenreName = "Adventure" },
                new Genre() { Id = 3, GenreName = "Science Fiction" },
                new Genre() { Id = 4, GenreName = "Drama" },
                new Genre() { Id = 5, GenreName = "Mystery" }
            });

            modelBuilder.Entity<Book>().HasData(new[]
            {
                new Book()
                {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    GenreId = 1,
                    NumberOfPages = 1178,
                    Year = 1954,
                    Price = 20,
                    Stock = 10,
                    Description = "Published by Allen & Unwin",
                    AuthorId = 1,
                    TrilogiesId = 1,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1566425108i/33.jpg"
                },
                new Book()
                {
                    Id = 2,
                    Title = "The Hobbit",
                    GenreId = 2,
                    NumberOfPages = 310,
                    Year = 1937,
                    Price = 15,
                    Stock = 10,
                    Description = "Published by Allen & Unwin",
                    AuthorId = 1,
                    TrilogiesId = 1,
                    ImageUrl = "https://www.britishbook.ua/upload/resize_cache/iblock/3ae/r816m7e8jmluhoml6zvy2yhloaoa4ya2/340_500_174b5ed2089e1946312e2a80dcd26f146/kniga_the_hobbit.jpg"
                },
                new Book()
                {
                    Id = 3,
                    Title = "The Silmarillion",
                    GenreId = 1,
                    NumberOfPages = 365,
                    Year = 1977,
                    Price = 25,
                    Stock = 10,
                    Description = "Published by Allen & Unwin",
                    AuthorId = 1,
                    TrilogiesId = 1,
                    ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/196236109.jpg"
                },
                new Book()
                {
                    Id = 4,
                    Title = "Harry Potter and the Philosopher's Stone",
                    GenreId = 1,
                    NumberOfPages = 223,
                    Year = 1997,
                    Price = 18,
                    Stock = 10,
                    Description = "Published by Bloomsbury",
                    AuthorId = 2,
                    TrilogiesId = 2,
                    ImageUrl = "https://m.media-amazon.com/images/I/81q77Q39nEL.jpg"
                },
                new Book()
                {
                    Id = 5,
                    Title = "Harry Potter and the Chamber of Secrets",
                    GenreId = 1,
                    NumberOfPages = 251,
                    Year = 1998,
                    Price = 20,
                    Stock = 10,
                    Description = "Published by Bloomsbury",
                    AuthorId = 2,
                    TrilogiesId = 2,
                    ImageUrl = "https://static.yakaboo.ua/media/catalog/product/9/7/9781408855669.jpg"
                }
            });

            modelBuilder.Entity<Author>().HasData(new[]
            {
                new Author()
                {
                    Id = 1,
                    AuthorName = "J.R.R. Tolkien"
                },
                new Author()
                {
                    Id = 2,
                    AuthorName = "J.K. Rowling"
                },
                new Author()
                {
                    Id = 3,
                    AuthorName = "George R.R. Martin"
                },
                new Author()
                {
                    Id = 4,
                    AuthorName = "C.S. Lewis"
                },
                new Author()
                {
                    Id = 5,
                    AuthorName = "Suzanne Collins"
                }
            });

            modelBuilder.Entity<Trilogies>().HasData(new []
            {
                new Trilogies()
                {
                    Id = 1,
                    TrilogieName = "The Lord of the Rings"
                },
                new Trilogies()
                {
                    Id = 2,
                    TrilogieName = "Harry Potter"
                },
                new Trilogies()
                {
                    Id = 3,
                    TrilogieName = "A Song of Ice and Fire"
                },
                new Trilogies()
                {
                    Id = 4,
                    TrilogieName = "The Chronicles of Narnia"
                },
                new Trilogies()
                {
                    Id = 5,
                    TrilogieName = "The Hunger Games"
                }
            });

        }
    }
}
