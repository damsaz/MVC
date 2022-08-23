using MVC1.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
    {
    public class Person
        {
        [Required]
        public string First_name;
        [Required]
        public string Last_name;
        [Required]
        public string Country;
        [Required]
        public string Tel;

        public Person( string first_name, string last_name, string country, string tel)
            {
         
            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            }
        }
    }
// { "id":20,"first_name":"Juan","last_name":"Evans","email":"jevansj@google.de","country":"Philippines","modified":"2015-07-09","vip":true,"Tel":"073955214"}]'
public class Student
    {
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Gender { get; set; }
    }