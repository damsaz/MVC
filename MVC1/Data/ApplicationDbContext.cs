using Microsoft.EntityFrameworkCore;
using MVC1.Models;

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

            public DbSet<Person> People { get; set; }
            }
        }
