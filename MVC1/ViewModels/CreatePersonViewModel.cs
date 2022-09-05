using MVC1.Models;
using System.Diagnostics.Metrics;

namespace MVC1.ViewModels
{
    public class CreatePersonViewModel
        {
        internal static void Create(string tel, string first_name, string last_name, string City)
            {
            PeopleViewModel people2 = new PeopleViewModel();
            people2.people = PeopleManager.people.people.Where(people => people.First_name.ToLower() == first_name.ToLower() && people.Last_name.ToLower() == last_name.ToLower()).ToList();
            if (people2.people.Count == 0)
                {
                Person person = new(first_name, last_name, City, tel, new List<Language> {new Language()});
                PeopleManager.MaxId++;
                PeopleManager.people.people.Add(person);
                }
            }
        }
    }
