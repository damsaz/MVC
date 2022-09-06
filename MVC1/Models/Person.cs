using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{

    public class Person
    {
      
        [Required]
        public int Id { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public City city { get; set; }
        public string CityName { get; set; }

        public string Tel { get; set; }
        public List<Language> Languages { get; set; }

       
    }
}
