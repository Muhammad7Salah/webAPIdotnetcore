using System;
using Newtonsoft.Json;

namespace SeDes
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = doSerialization();
            System.Console.WriteLine(json);
            System.Console.WriteLine("================");
            doDeSerialization(json);
        }

        public static string doSerialization()
        {
            Rocket[] rockets = {
                new Rocket{ ID = 0, Builder = "NASA", Target = "Moon", Speed=7.8},
                new Rocket{ ID = 1, Builder = "NASA", Target = "Mars", Speed=10.9},
                new Rocket{ ID = 2, Builder = "NASA", Target = "Kepler-452b", Speed=42.1},
                new Rocket{ ID = 3, Builder = "NASA", Target = "N/A", Speed=0}
                };

            return JsonConvert.SerializeObject(rockets);
        }

        public static void doDeSerialization(string json)
        {
               var rockets = JsonConvert.DeserializeObject<Rocket[]>(json);

               foreach (var r in rockets)
               {
                   Console.WriteLine($"ID:{r.ID} Builder:{r.Builder} Target:{r.Target} Speed:{r.Speed}");
               }

                /*var ufos = JsonConvert.DeserializeObject<UFO[]>(json);
                foreach (var ufo in ufos) {
                Console.WriteLine($"Target:{ufo.Target} Speed:{ufo.Speed}");
                }*/
        }

    }
}
