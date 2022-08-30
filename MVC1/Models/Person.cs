using System.ComponentModel.DataAnnotations;
namespace MVC1.Models
    {

    public class Person
        {
        [Required]
        public int Id { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Country { get; set; }

        public string Tel { get; set; }


        public Person(string first_name, string last_name, string country, string tel, int id)
            {
            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            Id = id;
            }
        public Person(int id, string first_name, string last_name, string country, string tel)
            {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            }
        public Person() { }
        }
    }
