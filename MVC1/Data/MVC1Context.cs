using System;
using System.Collections.Generic;
using System.Linq;
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
            modelBuilder.Entity<Person>().HasData(GetPerson());

            }

        public DbSet<MVC1.Models.Person> Person { get; set; }
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
        }
}
