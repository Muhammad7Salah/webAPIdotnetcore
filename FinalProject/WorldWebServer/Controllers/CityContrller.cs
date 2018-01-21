using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers{

    [Route("api/[Controller]")]
    public class CityController:Controller
    {
        private WorldDbContext dbContext;

        public CityController(){
            var connString = "server=localhost;port=3306;database=world;userid=root;pwd=Zewail@1995;sslmode=none";
            dbContext = WorldDbContextFactory.create(connString);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(dbContext.city.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var target = dbContext.city.SingleOrDefault(cty =>cty.ID == id);
            if(target != null)
            {
                return Ok(target);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("cc/{cc}")]
        public ActionResult Get(string cc)
        {
            var cities = this.dbContext.city
            .Where(ct => string.Equals(ct.CountryCode, cc, StringComparison.CurrentCultureIgnoreCase))
            .ToArray();
            return Ok(cities);
        }

        [HttpPost]
        public ActionResult Post([FromBody] City city) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            dbContext.city.Add(city);
            dbContext.SaveChanges();
            return Created($"api/cities/{city.ID}", city);
        }

        [HttpPut("id")]
        public ActionResult Update([FromRoute]int id, [FromBody] City cty)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var target = dbContext.city.SingleOrDefault(t=>t.ID == id);

            if(target!=null)
            {
                target.Name = cty.Name;
                target.CountryCode = cty.CountryCode;
                target.District = cty.District;
                target.Population = cty.Population;
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }
            [HttpDelete("{id}")]
            public ActionResult Delete(int id) {
            City target = this.dbContext.city.SingleOrDefault(ct => ct.ID == id);
            if (target != null) {
                this.dbContext.city.Remove(target);
                this.dbContext.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
        }

    }

    
}
