using MVC1.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC1.ViewModels
    {
    public class CountryViewModel
        {
        public IList<Country> CountryList { get; set; }    
        }
    }
