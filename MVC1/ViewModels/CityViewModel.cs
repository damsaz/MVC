using MVC1.Models;

namespace MVC1.ViewModels
{
    public class CityViewModel
        {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public IList<Person> people;
        }
    }
