using Microsoft.EntityFrameworkCore;
using MVC1.Models;

namespace MVC1.Data
    {
    internal class DbInitializer
        {
        private ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
            {
            this.modelBuilder = modelBuilder;
            }

        internal void Seed()
            {
          //  modelBuilder.Entity<Person>().HasData(PeopleManager.GetPerson ); 
            }
        }
    }