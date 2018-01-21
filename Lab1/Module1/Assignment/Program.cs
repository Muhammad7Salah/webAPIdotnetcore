using System;
using Newtonsoft.Json;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var product1 = new Product{ID=1,Name="Zamalek",Price=233.2};
            string json = DoSerialization(product1);
            Console.WriteLine(json);

            DoDeSerialization(json);
        }

        public static string DoSerialization(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            return json;
        }

        public static void DoDeSerialization(string json)
        {
            var product2 = JsonConvert.DeserializeObject<Product>(json);

            Console.WriteLine($"ID:{product2.ID} Name:{product2.Name} Price:{product2.Price}");
        }
    }
}
