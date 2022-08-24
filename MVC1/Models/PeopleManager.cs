using MVC1.ViewModels;
using Newtonsoft.Json;

namespace MVC1.Models
    {
    public class PeopleManager
        {
    
        public static string[] ?filePaths;
        public static PeopleViewModel people;
        public static string Jsontext { get; set; }
        public static int MaxId { get; set; }

        internal static PeopleViewModel Delete(int id)
        {
            PeopleManager.people.people = PeopleManager.people.people.Where(people => people.Id != id).ToList();
            return PeopleManager.people;
        }

        internal static PeopleViewModel GetPeople()
        {


            using (StreamReader sr = new StreamReader(filePaths[0]))
            {

                people = JsonConvert.DeserializeObject<PeopleViewModel>(sr.ReadToEnd());

            }
            MaxId = people.people.Count;
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

        internal static PeopleViewModel SearchById(int id)
        {
            PeopleViewModel p2 = new PeopleViewModel();
            if (id!=0)
            {

                PeopleViewModel people = PeopleManager.GetPeopleList();
                List<Person> people2 = (List<Person>)people.people;
                p2.people = people2.Where(people => people.Id==id).ToList();
            }
            if(p2.people.Count==0)
                p2 = PeopleManager.people;
            return p2;
        }
    }
    }
