

using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class Language
    {
        [Key]
        public int IdLanguage { get; set; }
        public string Name { get; set; }
        public List<Person> people { get; set; }

    }
    public class LanguageVM
    {
 
        public List<Language> Languages { get; set; }

    }
}
