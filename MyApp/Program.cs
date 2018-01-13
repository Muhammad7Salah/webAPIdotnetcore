using System;
using Newtonsoft.Json;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Product1= new Product{ID=1,Name="Surface",Price=300};
            
            var jsonString = JsonConvert.SerializeObject(Product1);

            Console.WriteLine(jsonString);

            var Product2 = JsonConvert.DeserializeObject<Product>(jsonString);

            Console.WriteLine($"Name: {Product2.Name}");
            Console.WriteLine($"ID: {Product2.ID}");
            Console.WriteLine($"Price: {Product2.Price}");
        }
    }

    class Product
    {
        public int ID{get;set;}
        public string Name{get;set;}
        public double Price{get;set;}
    }
}
