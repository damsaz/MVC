using System;
using System.ComponentModel.DataAnnotations;
using MVC1.Models;

namespace MVC1.ViewModels
{
    public class PeopleViewModel
        {
        public int Id { get; set; } 
        public IList<Person> people;

        }
    }
