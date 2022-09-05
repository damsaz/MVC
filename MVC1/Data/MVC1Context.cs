using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC1.Models;
using MVC1.ViewModels;
using Newtonsoft.Json;

namespace MVC1.Data
{
    public class MVC1Context : DbContext
    {
        
        public MVC1Context (DbContextOptions<MVC1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Language>().HasData(GetLang());
            
            modelBuilder.Entity<Person>().HasData(GetPerson());
           modelBuilder.Entity<Person>().HasMany(l=>l.Languages).WithMany(p=>p.people).UsingEntity(J=>J.HasData(GetLangPeop()));
            

            }
        

        public DbSet<Person> Person { get; set; }
        public DbSet<Language> Language { get; set; }
        public List<Person> GetPerson()
            {
            PeopleViewModel people2;
            List<Person> peoplelist = new List<Person>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\peopleMock.json"))
                {



                people2 = JsonConvert.DeserializeObject<PeopleViewModel>(sr.ReadToEnd());
                peoplelist = people2.people.ToList();

                }
            return peoplelist;
            }
        public List<LanguagePerson> GetLangPeop()
        {
            LanguagePersonVM languagePerso;
            List<LanguagePerson> peoplelist = new List<LanguagePerson>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\LanguagePerson.json"))
            {



                languagePerso = JsonConvert.DeserializeObject<LanguagePersonVM>(sr.ReadToEnd());
                peoplelist = languagePerso.LanguagePerson.ToList();

            }
            return peoplelist;
        }
        public static List<Language> GetLang()
        {
            LanguageVM languagePerso;
            List<Language> peoplelist = new List<Language>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\Language.json"))
            {



                languagePerso = JsonConvert.DeserializeObject<LanguageVM>(sr.ReadToEnd());
                peoplelist = languagePerso.Languages.ToList();

            }
            return peoplelist;
        }
    
    }
}
