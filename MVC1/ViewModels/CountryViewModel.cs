using System.ComponentModel.DataAnnotations;

namespace MVC1.ViewModels
    {
    public class CountryViewModel
        {
        [Key]
        public string CountryId { get; set; }
        public string Name { get; set; }    

        public List<CityViewModel> cities;
        }
    }
