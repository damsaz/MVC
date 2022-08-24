using MVC1.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC1.ViewModel
    {
    public class PeopleViewModel
        {
        [Required]
        public string First_name;
        [Required]
        public string Last_name;
        [Required]
        public string Country;
        [Required]
        public string Tel;
        public IList<Person> people;
     
        public void Person(string first_name, string last_name, string country, string tel)
            {

            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            }
        }
    }
