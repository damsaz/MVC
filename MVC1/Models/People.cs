using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class People
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
    }
}
