using Microsoft.EntityFrameworkCore;

namespace WorldWebServer.Models
{
    public class WorldDbContext:DbContext
    {
        public WorldDbContext(DbContextOptions options)
        :base(options){ }

        public DbSet<Country> country {get; set;}
        public DbSet<City> city {get;set;}
    }

    public class WorldDbContextFactory {

        public static WorldDbContext create(string ConnectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WorldDbContext>();
            optionsBuilder.UseMySQL(ConnectionString);
            var dbContext = new WorldDbContext(optionsBuilder.Options);
            return dbContext;
        }

    }
}