using Book_Shop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Data
{
    public class BookShopDbContext : IdentityDbContext<User>  
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) :base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Trilogies> Trilogies { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedBooks();
            modelBuilder.SeedGenres();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedTrilogies();

            modelBuilder.Entity<OrderDetails>().HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderDetails>().HasOne(x => x.Book).WithMany(x => x.Orders).HasForeignKey(x => x.BookId);
        }
    }
}
