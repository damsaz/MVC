using System.ComponentModel.DataAnnotations;
namespace MVC1.Models
    {
    
    public class Person
        {
        [Required]
        public int Id;
        [Required]
        public string First_name;
        [Required]
        public string Last_name;
        [Required]
        public string Country;
        [Required]
        public string Tel;
        private int v;

        public Person(string first_name, string last_name, string country, string tel, int v)
            {
            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            this.v = v;
            }
        }
    }
