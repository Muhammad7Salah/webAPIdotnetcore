using System.ComponentModel.DataAnnotations;

namespace SakilaWebServer.Models{

    public class Actor{
        [Key]
        public int Actor_id {get; set;}
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

    }

}