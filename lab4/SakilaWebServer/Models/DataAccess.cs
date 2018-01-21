using Microsoft.EntityFrameworkCore;

namespace SakilaWebServer.Models{

    public class SakilaDbContext : DbContext {
        public SakilaDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Actor> Actor {get; set;}

    }
        class SakilaDbContextFactory 
        {
            public static SakilaDbContext Create(string connectionString)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SakilaDbContext>();
                optionsBuilder.UseMySQL(connectionString);
                var dbContext = new SakilaDbContext(optionsBuilder.Options);
                return dbContext;
            }
        }


}