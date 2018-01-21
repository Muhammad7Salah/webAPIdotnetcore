using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using System.Collections.Generic;

namespace MyAPI.Controllers{

    [Route("api/[Controller]")] 
    public class ProductsController:Controller
    {
        [HttpGet]
        public ActionResult Get(){
            if(FakeData.Products.Count>0)
                return Ok(FakeData.Products.Values.ToArray());
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(int id)
        {
            if(FakeData.Products.ContainsKey(id))
            {
                return Ok(FakeData.Products[id]);
            }
            else
                return NotFound();
        }

        [HttpGet("Price/{min}/{max}")]
        public ActionResult GetFiltering(int min, int max)
        {
            var products = new List<Product>();
            
            products.Clear();
            foreach (var item in FakeData.Products)
            {
                if(item.Value.Price < max && item.Value.Price > min)
                {
                    products.Add(item.Value);
                }
            }

            if(products.Count>0)
            {
                return Ok(products.ToArray());
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id){
            if(FakeData.Products.ContainsKey(id))
            {
                FakeData.Products.Remove(id);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult CreateItem([FromBody]Product product)
        {
            product.ID = FakeData.Products.Keys.Max()+1;
            FakeData.Products.Add(product.ID,product);
            return Created($"/{product.ID}",product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id,[FromBody] Product product)
        {
            if(FakeData.Products.ContainsKey(id))
            {
                FakeData.Products[id] = product;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("raise/{amount}")]
        public ActionResult RaisePrice(double amount,Product product)
        {
            if(FakeData.Products.Count>0)
            {
                foreach (var item in FakeData.Products.Values.ToArray())
                {
                    item.Price+=amount;
                }
                    return Ok();
            }
            else
            {
                return NoContent();
            }
        }
    }

}