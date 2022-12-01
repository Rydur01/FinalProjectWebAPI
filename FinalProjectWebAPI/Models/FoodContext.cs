using FinalProjectWebAPI.Controllers;
using FinalProjectWebAPI.FoodModels;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
        public DbSet<Food>? Foods { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                new Food { FoodId = 1, Name = "Strawberries", Group = "Fruit", Price = 10.99, Calories = 150 }
            );

            modelBuilder.Entity<Show>().HasData(
                new Show { ShowID = 1, ShowsName = "South Park", Person = "Grant Kollar", Seasons = 23, WhereToWatch = "YouTube TV" },
                new Show { ShowID = 2, ShowsName = "The Boys", Person = "Jacob", Seasons = 3, WhereToWatch = "Amazon" }
            );

            modelBuilder.Entity<Hobbies>().HasData(
                new Hobbies { Id = 1, Name = "Mo Daniel", Hobby = "Studying the bible", Reason = "To Know who I am", Days = "Everyday" }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { ID = 1, Name = "Nathan Burns", Birthday = new DateTime(2002, 12, 14), Program = "Information Technology", Year = "2nd Year" },
                new Person { ID = 2, Name = "Ryan Durham", Birthday = new DateTime(2001, 1, 7), Program = "Information Technology", Year = "4th Year" },
                new Person { ID = 3, Name = "Modupeoluwa Daniel", Birthday = new DateTime(2003, 6, 14), Program = "Information Technology", Year = "3rd Year" },
                new Person { ID = 4, Name = "Grant Kollar", Birthday = new DateTime(2000, 2, 19), Program = "Cyber Security", Year = "5th Year" }
           );

    }
        

        
    }
}
