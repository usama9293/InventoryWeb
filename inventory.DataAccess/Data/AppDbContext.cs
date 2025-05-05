using Microsoft.EntityFrameworkCore;
using Inventory.Models;


namespace inventory.DataAccess.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {


        }

        public DbSet<Category>Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Acton", Description = "have some actions" },
               new Category { Id = 2, Name = "history", Description = "have some history" },
               new Category { Id = 3, Name = "Default", Description = "default history " }

                );
            modelBuilder.Entity<Product>().HasData(
        new Product
        {
            Id = 1,
            Title = "The Art of War",
            Description = "A book on military strategy",
            Author = "Sun Tzu",
            ISBN = "1234567890",
            listPrice = 150,
            Price = 120,
            Price50 = 100,
            Price100 = 80,
            CategoryId = 1,
            ImageUrl = ""
        },
        new Product
        {
            Id = 2,
            Title = "1984",
            Description = "Dystopian novel by George Orwell",
            Author = "George Orwell",
            ISBN = "2345678901",
            listPrice = 180,
            Price = 140,
            Price50 = 110,
            Price100 = 90,
            CategoryId = 2,
            ImageUrl = ""
        }
    );

        }
    }
}
