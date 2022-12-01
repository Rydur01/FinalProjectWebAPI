using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }
        public DbSet<Food>? Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, Name = "Strawberries", Group = "Fruit", Price = 10.99, Calories = 150 });
        }
    }
}
