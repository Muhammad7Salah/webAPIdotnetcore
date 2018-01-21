using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers{
    
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        //[Route("all")]
        [HttpGet]
        public Product[] Get(){
            return FakeData.Products.Values.ToArray();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id){
            if(FakeData.Products.ContainsKey(id))
                return FakeData.Products[id];
            else
                return null;
        }

        [HttpGet("from/{low}/to/{high}")]
        public Product[] Get(int low, int high) {
        var products = FakeData.Products.Values
        .Where(p => p.Price >= low && p.Price <= high).ToArray();
        return products;
        }

        [HttpPost]
        public Product addProduct([FromBody] Product product){
            product.ID = FakeData.Products.Keys.Max()+1;
            FakeData.Products.Add(product.ID,product);
            return product;
        }

        [HttpPut("{id}")]
        public void updateProduct(int id,[FromBody] Product p )
        {
            Product product = FakeData.Products[id];
            product.Name = p.Name;
            product.Price = p.Price;
        }

        [HttpDelete("{id}")]
        public void deleteProduct(int id){
            if(FakeData.Products.ContainsKey(id))
                FakeData.Products.Remove(id);
        }
    }
}