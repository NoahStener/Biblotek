using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                BookID = 1,
                Title = "Harry Potter and the Sorcerer's Stone",
                Author = "J.K. Rowling",
                YearOfRelease = 1997,
                Genre = "Fantasy",
                Description = "The first book in the Harry Potter series. Introducing the young wizard Harry Potter.",
                IsAvaliable = true,
            },
            new Book
            {
                BookID = 2,
                Title = "A Game of Thrones",
                Author = "George R.R. Martin",
                YearOfRelease = 1996,
                Genre = "Fantasy",
                Description = "The first book in the A Song of Ice and Fire series, where the struggle for the Iron Throne begins",
                IsAvaliable = false,
            },
            new Book
            {
                BookID = 3,
                Title = "The Fellowship of the Ring",
                Author = "J.R.R. Tolkien",
                YearOfRelease = 1954,
                Genre = "Fantasy",
                Description = "The first book in the Lord of the Rings trilogy, where the journey of the One Ring begins.",
                IsAvaliable = true,
            },
            new Book
            {
                BookID = 4,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                YearOfRelease = 1925,
                Genre = "Classic Fiction",
                Description = "A novel that critiques the American dream through the tragic story of Jay Gatsby",
                IsAvaliable = true,
            });

        }
    }
}
