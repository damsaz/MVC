using Microsoft.EntityFrameworkCore;
using MVC1.Data;

namespace MVC1.Models
{
    internal class PeopleManagerEF
        {
        private MVC1Context _context;

        public PeopleManagerEF(MVC1Context context)
            {
            this._context = context;
            }

        internal async Task<object> ? SearchEF(string searchName)
            {
           Person person = await _context.Person
               .FirstOrDefaultAsync(m => m.First_name.ToLower().Contains(searchName.ToLower()));
            
            if (person == null)
                {
               // return NotFound();
                }
            return person;
            }
        }
    }