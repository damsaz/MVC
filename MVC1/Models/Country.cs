using MVC1.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class Country
    {
        [Key]
        public string CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
        }
}