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

        public IList<PeopleViewModel> people;
      
    public PeopleViewModel()
        {
        First_name = "";
        Last_name = "";
        Country = "";
        Tel = "";
        Id = 0;
        }

    public PeopleViewModel(string first_name, string last_name, string country, string tel, int id)
        {

        First_name = first_name;
        Last_name = last_name;
        Country = country;
        Tel = tel;
        Id = id;
        }
        }
    }
