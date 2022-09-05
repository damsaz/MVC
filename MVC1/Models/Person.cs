using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{

    public class Person
    {
      

        public Person(string first_name, string last_name, string city, string tel, List<Language> list)
            {
            First_name = first_name;
            Last_name = last_name;
            City = city;
            Tel = tel;
            Languages = list;
            }
        public Person()
            {

            }

        [Required]
        public int Id { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string City { get; set; }

        public string Tel { get; set; }
        public List<Language> Languages { get; set; }

       
    }
}
