using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class City
    {
        [Key]
        public string CityName { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string CountryId { get; set; }
        public Country Country;
        public IList<Person> people { get; set; }
        }
}