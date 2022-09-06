using MVC1.Data;
using MVC1.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MVC1.Models
{
    public class PeopleManager
        {
    
        public static string[] ?filePaths;
        public static PeopleViewModel people;
        internal static MVC1Context context;
        private static LanguagePersonVM languagePerso;

        public static string Jsontext { get; set; }
        public static int MaxId { get; set; }

        internal static PeopleViewModel Delete(int id)
        {
            PeopleManager.people.people = PeopleManager.people.people.Where(people => people.Id != id).ToList();
            return PeopleManager.people;
        }

        internal static PeopleViewModel GetPeople()
        {

            List<Person> peoplelist = new List<Person>();
            List < LanguagePerson> languagePerson = new List<LanguagePerson>();
            using (StreamReader sr = new StreamReader(filePaths[4]))
                {

                people = JsonConvert.DeserializeObject<PeopleViewModel>(sr.ReadToEnd());
                peoplelist = people.people.ToList();

                }
            using (StreamReader sr = new StreamReader(filePaths[3]))
            {

                languagePerso = JsonConvert.DeserializeObject<LanguagePersonVM>(sr.ReadToEnd());
                

            }
          
            MaxId = people.people.Count;
            GetCity();
            return people;
            }
        public static List<City> GetCity()
            {
            CityViewModel Cities;
            List<City> cityList = new List<City>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\cities.json"))
                {



                Cities = JsonConvert.DeserializeObject<CityViewModel>(sr.ReadToEnd());
                cityList = Cities.CityList.ToList();

                }
            return cityList;
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
                p2.people = (IList<Person>)people2.Where(people => people.First_name.ToLower().Contains(searchName.ToLower())).ToList();
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
                p2.people = (IList<Person>)people2.Where(people => people.Id==id).ToList();
                if (p2.people.Count == 0)
                    p2 = PeopleManager.people;
                }
            else
               p2= PeopleManager.people;
            return p2;
        }

        
        }
    }
