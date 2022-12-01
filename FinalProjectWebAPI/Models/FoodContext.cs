using FinalProjectWebAPI.FoodModels;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
        public DbSet<Food>? Foods { get; set; }
        public DbSet<Show> Shows { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                new Food { FoodId = 1, Name = "Strawberries", Group = "Fruit", Price = 10.99, Calories = 150 });
            modelBuilder.Entity<Show>().HasData(
                new Show { ShowID = 1, ShowsName = "South Park", Person = "Grant Kollar", Seasons = 23, WhereToWatch = "YouTube TV" },
                new Show { ShowID = 2, ShowsName = "The Boys", Person = "Jacob", Seasons = 3, WhereToWatch = "Amazon" });
        }
        

        
    }
}
