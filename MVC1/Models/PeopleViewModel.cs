using Newtonsoft.Json;

namespace MVC1.Models
    {
    public class PeopleViewModel
        {
    
        public static string[] ?filePaths;
        public static People people;
        public static string Jsontext { get; set; }
        public static int MaxId { get; set; }

        internal static People Delete(int id)
        {
            PeopleViewModel.people.people = PeopleViewModel.people.people.Where(people => people.Id != id).ToList();
            return PeopleViewModel.people;
        }

        internal static People GetPeople()
        {


            using (StreamReader sr = new StreamReader(filePaths[0]))
            {

                people = JsonConvert.DeserializeObject<People>(sr.ReadToEnd());

            }
            MaxId = people.people.Count;
            return people;
            }
        internal static People GetPeopleList()
        {

            return people;
        }

        internal static People Search(string searchName)
        {
            People p2 = new People();
            if (!String.IsNullOrEmpty(searchName))
            {

                People people = PeopleViewModel.GetPeopleList();
                List<Person> people2 = (List<Person>)people.people;
                p2.people = people2.Where(people => people.First_name.ToLower().Contains(searchName.ToLower())).ToList();
            }
            else
                p2 = PeopleViewModel.people;
            return p2;
        }

        internal static void Sort(int sort)
            {

            if (sort == 1)
                PeopleViewModel.people.people = PeopleViewModel.people.people.OrderBy(x => x.First_name).ToList();
            if (sort == 2)
                PeopleViewModel.people.people = PeopleViewModel.people.people.OrderBy(x => x.Last_name).ToList();
            }

        internal static People SearchById(int id)
        {
            People p2 = new People();
            if (id!=0)
            {

                People people = PeopleViewModel.GetPeopleList();
                List<Person> people2 = (List<Person>)people.people;
                p2.people = people2.Where(people => people.Id==id).ToList();
            }
            else 
                p2 = PeopleViewModel.people;
            if(p2.people.Count==0)
                p2 = PeopleViewModel.people;
            return p2;
        }
    }
    }
