using InventoryWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryWeb.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {


        }

        public DbSet<Category>Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Acton", Description = "have some actions" },
               new Category { Id = 2, Name = "history", Description = "have some history" },
               new Category { Id = 3, Name = "Default", Description = "default history " }

                );
        }
    }
}
