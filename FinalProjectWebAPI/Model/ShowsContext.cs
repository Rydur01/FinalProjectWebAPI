using FinalProjectWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Model
{
    public class ShowsContext : DbContext
    {
        public ShowsContext(DbContextOptions<ShowsContext> options) : base(options) { }
        public DbSet<Show> Shows { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Show>().HasData(
                new Show { ID = 1, ShowsName = "South Park", Person = "Grant Kollar", Seasons = 23, WhereToWatch = "YouTube TV"},
                new Show { ID = 2, ShowsName = "The Boys", Person = "Jacob", Seasons = 3 , WhereToWatch= "Amazon"}


           );
        }

    }
}