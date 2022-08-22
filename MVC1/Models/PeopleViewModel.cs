using Newtonsoft.Json;

namespace MVC1.Models
    {
    public class PeopleViewModel
        {
    
        public static string[] ?filePaths;
        private static People people;

        internal static People GetPeople()
            {
   

                using (StreamReader sr = new StreamReader(filePaths[0]))
                    {
                     people = JsonConvert.DeserializeObject<People>(sr.ReadToEnd());
                    }

            return people;
            }
        }
    }
