using MVC1.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC1.ViewModels
    {
    public class PeopleViewModel
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
        public IList<Person> people;
        }
    }
