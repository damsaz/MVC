using Microsoft.EntityFrameworkCore;
using MVC1.Models;
using MVC1.ViewModels;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MVC1.Data
{
   
    public class ApplicationDbContext : DbContext
            {
            public ApplicationDbContext()
                {

                }

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
                {

                }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Person>().HasData(GetPerson());

            }

        public DbSet<Person> People { get; set; }

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
