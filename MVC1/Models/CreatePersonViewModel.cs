using System.Diagnostics.Metrics;

namespace MVC1.Models
    {
    public class CreatePersonViewModel
    {
        internal static void Create(string tel, string first_name, string last_name, string country)
        {
            People people2=new People() ;
            people2.people= PeopleViewModel.people.people.Where(people => people.First_name.ToLower()== first_name.ToLower() && people.Last_name.ToLower() == last_name.ToLower()).ToList();
            if (people2.people.Count == 0) { 
            Person person = new(first_name, last_name, country, tel, (people2.people.Count+1));
            PeopleViewModel.people.people.Add(person);
            }
        }
    }
}
