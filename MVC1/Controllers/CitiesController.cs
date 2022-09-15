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
    [Authorize(Roles = "Administrator")]
    public class CitiesController : Controller
    {
        private readonly MVC1Context _context;

        public CitiesController(MVC1Context context)
        {
            _context = context;
        }

      
        public IActionResult Index()
        {
            var mVC1Context = _context.City.Include(c => c.Country);
            return View( mVC1Context.ToList());
        }

     
        public  IActionResult Details(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city =  _context.City
                .Include(c => c.Country)
                .FirstOrDefault(m => m.IdCity == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

     
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId");
            return View();
        }

        [HttpPost]
      
        public  IActionResult Create([Bind("IdCity,CityName,CountryId")] City city)
        {
            ModelState.Remove("people");
            if (ModelState.IsValid)
            {
                _context.Add(city);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId", city.CountryId);
            return View(city);
        }

      
        public  IActionResult Edit(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city =  _context.City.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId", city.CountryId);
            return View(city);
        }

        [HttpPost]
    
        public  IActionResult Edit(int id, [Bind("IdCity,CityName,CountryId")] City city)
        {
            if (id != city.IdCity)
            {
                return NotFound();
            }
            ModelState.Remove("people");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.IdCity))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId", city.CountryId);
            return View(city);
        }

  
        public  IActionResult Delete(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city =  _context.City
                .Include(c => c.Country)
                .FirstOrDefault(m => m.IdCity == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }


        [HttpPost, ActionName("Delete")]
    
        public  IActionResult DeleteConfirmed(int id)
        {
            if (_context.City == null)
            {
                return Problem("Entity set 'MVC1Context.City'  is null.");
            }
            var city =  _context.City.Find(id);
            if (city != null)
            {
                _context.City.Remove(city);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
          return (_context.City?.Any(e => e.IdCity == id)).GetValueOrDefault();
        }
    }
}
