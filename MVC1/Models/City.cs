﻿using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class City
    {
        [Key]
         public int IdCity { get; set; }   
        public string CityName { get; set; }
        public string CountryId { get; set; }
        public Country Country;
       
        public ICollection<Person> people { get; set; }
    }
}