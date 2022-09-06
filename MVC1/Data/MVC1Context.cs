using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            modelBuilder.Entity<Person>()
           .HasOne(p => p.city)
           .WithMany(b => b.people)
           .HasForeignKey(p => p.CityName);


            }
        

        public DbSet<Person> Person { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<City> City { get; set; }
      
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
            List<LanguagePerson> LangPeoplist = new List<LanguagePerson>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\LanguagePerson.json"))
            {



                languagePerso = JsonConvert.DeserializeObject<LanguagePersonVM>(sr.ReadToEnd());
                LangPeoplist = languagePerso.LanguagePerson.ToList();

            }
            return LangPeoplist;
        }
        public static List<Language> GetLang()
        {
            LanguageVM language;
            List<Language> Langlist = new List<Language>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\Language.json"))
            {



                language = JsonConvert.DeserializeObject<LanguageVM>(sr.ReadToEnd());
                Langlist = language.Languages.ToList();

            }
            return Langlist;
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
        public static List<Country> GetCountry()
            {
            CountryViewModel CountryVM;
            List<Country> CountryList = new List<Country>();

            using (StreamReader sr = new StreamReader(@"wwwroot\\jsonfile\\country.json"))
                {



                CountryVM = JsonConvert.DeserializeObject<CountryViewModel>(sr.ReadToEnd());
                CountryList = CountryVM.CountryList.ToList();

                }
            return CountryList;
            }

        }
}
