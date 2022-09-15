using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;

namespace MVC1.Controllers
    {
    
    [Authorize(Roles = "Administrator,User")]
 
    public class PeopleEFController : Controller
    {
        private readonly MVC1Context _context;

        public PeopleEFController(MVC1Context context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var mVC1Context = _context.Person.Include(p => p.city);
            return View( mVC1Context.ToList());
        }

        
        public  IActionResult Details(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person =  _context.Person
                .Include(p => p.city)
                .FirstOrDefault(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

       
        public IActionResult Create()
        {
            ViewData["IdCity"] = new SelectList(_context.City, "IdCity", "IdCity");
            return View();
        }


        [HttpPost]
       
        public IActionResult Create([Bind("Id,First_name,Last_name,IdCity,Tel")] Person person)
        {
            ModelState.Remove("Languages");
            ModelState.Remove("City");
            if (ModelState.IsValid) { 
                _context.Add(person);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                }
            ViewData["IdCity"] = new SelectList(_context.City, "IdCity", "IdCity", person.IdCity);
            return View(person);
        }

      
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person =  _context.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["IdCity"] = new SelectList(_context.City, "CityName", "CityName", _context.City.FirstOrDefault(c=>c.IdCity== person.IdCity).CityName);
            return View(person);
        }

        [HttpPost]
       
        public IActionResult Edit(int id, [Bind("Id", "First_name","Last_name" , "IdCity", "Tel")] Person person,string city)
        {
            person.IdCity=_context.City.FirstOrDefault(c => c.CityName == city).IdCity;
            if (id != person.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Languages");
            ModelState.Remove("City");
            if (ModelState.IsValid)
                {
                try
                    {
                    _context.Update(person);
                    _context.SaveChanges();
                    }
                catch (DbUpdateConcurrencyException)
                    {
                    if (!PersonExists(person.Id))
                        {
                        return NotFound();
                        }
                    else
                        {
                        throw;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            

            ViewData["IdCity"] = new SelectList(_context.City, "CityName", "CityName", _context.City.FirstOrDefault(p => p.IdCity == person.IdCity).CityName);
            return View(person);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person =  _context.Person
                .Include(p => p.city)
                .FirstOrDefault(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        
        [HttpPost, ActionName("Delete")]
       
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'MVC1Context.Person'  is null.");
            }
            var person =  _context.Person.Find(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
          return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
