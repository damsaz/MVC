using MVC1.Models;
using System.Diagnostics.Metrics;

namespace MVC1.ViewModels
    {
    public class CreatePersonViewModel
        {
        internal static void Create(string tel, string first_name, string last_name, string country)
            {
            PeopleViewModel people2 = new PeopleViewModel();
            people2.PeopleList = PeopleManager.people.PeopleList.Where(people => people.First_name.ToLower() == first_name.ToLower() && people.Last_name.ToLower() == last_name.ToLower()).ToList();
            if (people2.PeopleList.Count == 0)
                {
                PeopleViewModel person = new(first_name, last_name, country, tel, PeopleManager.MaxId + 1);
                PeopleManager.MaxId++;
                PeopleManager.people.PeopleList.Add(person);
                }
            }
        }
    }
