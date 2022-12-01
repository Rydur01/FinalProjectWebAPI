using FinalProjectWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Model
{
    public class ShowsContext : DbContext
    {
        public ShowsContext(DbContextOptions<ShowsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Show>().HasData(
                new Show { ID = 1, ShowsName = "South Park", Person = "Grant Kollar", Seasons = 23}

           );
        }

        public DbSet<Show> Shows { get; set; }
    }
}