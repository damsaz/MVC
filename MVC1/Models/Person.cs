using MVC1.Models;

namespace MVC1.Models
    {
    public class Person
        {
       public int Id;
       public string First_name;
       public string Last_name;
        public string Country;
       public string Tel;

        public Person(int id, string first_name, string last_name, string country, string tel)
            {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Country = country;
            Tel = tel;
            }
        }
    }
// { "id":20,"first_name":"Juan","last_name":"Evans","email":"jevansj@google.de","country":"Philippines","modified":"2015-07-09","vip":true,"Tel":"073955214"}]'
public class People
    {
    public IList<Person> people;
    }