using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SakilaWebServer.Models;


namespace SakilaWebServer.Controllers
{
    [Route("api/[Controller]")]
    public class ActorsController:Controller
    {
        private SakilaDbContext dbContext;
        
        public ActorsController()
        {
            string ConnectionString = "server=localhost;port=3306;database=sakila;userid=root;pwd=Zewail@1995;sslmode=none";
            dbContext = SakilaDbContextFactory.Create(ConnectionString);
        }


        [HttpGet]
        public ActionResult Get() => Ok(dbContext.Actor.ToArray());

        [HttpGet("{id}")]
        public ActionResult GetItem(int id)
        {
            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_id == id);
            if(actor != null)
                return Ok(actor);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult AddItem([FromBody]Actor actor)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            dbContext.Actor.Add(actor);
            dbContext.SaveChanges();
            return Created("api/[Controller]",actor);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id,[FromBody]Actor actor)
        {
           var target = dbContext.Actor.SingleOrDefault(a => a.Actor_id == id);
            if (target != null && ModelState.IsValid) {
                //dbContext.Entry(target).CurrentValues.SetValues(actor);
                target.First_Name = actor.First_Name;
                target.Last_Name = actor.Last_Name;
                dbContext.SaveChanges();
                return Ok();
            } else {
                return BadRequest();
            }
            
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var actor = dbContext.Actor.SingleOrDefault(a=>a.Actor_id == id);
            if(actor != null)
            {
                dbContext.Actor.Remove(actor);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }

}