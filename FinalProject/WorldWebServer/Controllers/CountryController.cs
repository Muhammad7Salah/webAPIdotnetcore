using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers{

    [Route("api/[controller]")]
    public class CountryController:Controller
    {
        private WorldDbContext dbContext;

        public CountryController(){
            var connString = "server=localhost;port=3306;database=world;userid=root;pwd=Zewail@1995;sslmode=none";
            this.dbContext = WorldDbContextFactory.create(connString);
        }

        [HttpGet()]
        public ActionResult Get()
        {
            return Ok(dbContext.country.ToArray());
        }
    }
}