using FinalProjectWebAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinalProjectWebAPI.Models
{
    public class HobbiesContext : DbContext
    {
        public HobbiesContext(DbContextOptions<HobbiesContext> options) : base(options)
        {
        }
        public DbSet<Hobbies>? Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobbies>().HasData(
                new Hobbies { Id = 1, Name = "Mo Daniel", Hobby = "Studying the bible", Reason = "To Know who I am", Days = "Everyday" });
        }
    }
}
