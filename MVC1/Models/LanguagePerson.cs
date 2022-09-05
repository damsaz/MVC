using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{
    public class LanguagePerson
    {
        
          
       
        public int LanguagesIdLanguage { get; set; }
      
        public int peopleId { get; set; }
 

    }
    public class LanguagePersonVM
    {

        public IList<LanguagePerson> LanguagePerson;
    }
}
