using MVC1.ViewModel;
using Newtonsoft.Json;

namespace MVC1.Models
    {
    public class PeopleManager
        {
    
        public static string[] ?filePaths;
        public static PeopleViewModel people;

        internal static PeopleViewModel Delete(string id)
        {
            PeopleManager.people.people = PeopleManager.people.people.Where(people => people.Tel != id).ToList();
            return PeopleManager.people;
        }

        internal static PeopleViewModel GetPeople()
            {
   
            
                using (StreamReader sr = new StreamReader(filePaths[0]))
                    {
                     people = JsonConvert.DeserializeObject<PeopleViewModel>(sr.ReadToEnd());
                    }

            return people;
            }
        internal static PeopleViewModel GetPeopleList()
        {

            return people;
        }

        internal static PeopleViewModel Search(string searchName)
        {
            PeopleViewModel p2 = new PeopleViewModel();
            if (!String.IsNullOrEmpty(searchName))
            {

                PeopleViewModel people = PeopleManager.GetPeopleList();
                List<Person> people2 = (List<Person>)people.people;
                p2.people = people2.Where(people => people.First_name.ToLower().Contains(searchName.ToLower())).ToList();
            }
            else
                p2 = PeopleManager.people;
            return p2;
        }

        internal static void Sort(int sort)
            {

            if (sort == 1)
                PeopleManager.people.people = PeopleManager.people.people.OrderBy(x => x.First_name).ToList();
            if (sort == 2)
                PeopleManager.people.people = PeopleManager.people.people.OrderBy(x => x.Last_name).ToList();
            }

 
        }
    }
