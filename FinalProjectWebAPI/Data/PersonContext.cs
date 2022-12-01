using FinalProjectWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasData(
                new Person { ID = 1, Name = "Nathan Burns", Birthday = new DateTime(2002, 12, 14), Program = "Information Technology", Year = "2nd Year" },
                new Person { ID = 2, Name = "Ryan Durham", Birthday = new DateTime(2001, 1, 7), Program = "Information Technology", Year = "4th Year" },
                new Person { ID = 3, Name = "Modupeoluwa Daniel", Birthday = new DateTime(2003, 6, 14), Program = "Information Technology", Year = "3rd Year" },
                new Person { ID = 4, Name = "Grant Kollar", Birthday = new DateTime(2000, 2, 19), Program = "Cyber Security", Year = "5th Year" }
           );
        }

        public DbSet<Person> People { get; set; }
    }
}
