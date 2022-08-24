using MVC1.Models;
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

        public Person()
            {
            First_name = "No results found";
            Last_name = "";
            Country = "";
            Tel = "";
            Id = 0;
            }

        public Person( string first_name, string last_name, string country, string tel, int id)
            {

            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            Id = id;
            }
        }
    }
// { "id":20,"first_name":"Juan","last_name":"Evans","email":"jevansj@google.de","country":"Philippines","modified":"2015-07-09","vip":true,"Tel":"073955214"}]'
