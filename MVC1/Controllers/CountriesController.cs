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
    public class CountriesController : Controller
    {
        private readonly MVC1Context _context;

        public CountriesController(MVC1Context context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
              return _context.Country != null ? 
                          View( _context.Country.ToList()) :
                          Problem("Entity set 'MVC1Context.Country'  is null.");
        }

    
        public IActionResult Details(string id)
        {
            if (id == null || _context.Country == null)
            {
                return NotFound();
            }

            var country =  _context.Country
                .FirstOrDefault(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

       
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
      
        public IActionResult Create([Bind("CountryId,Name")] Country country)
        {
            ModelState.Remove("City");
            if (ModelState.IsValid)
            {
                _context.Add(country);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

    
        public IActionResult Edit(string id)
        {
            if (id == null || _context.Country == null)
            {
                return NotFound();
            }

            var country =  _context.Country.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }


        [HttpPost]
      
        public IActionResult Edit(string id, [Bind("CountryId,Name")] Country country)
        {
            if (id != country.CountryId)
            {
                return NotFound();
            }
            ModelState.Remove("City");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryId))
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
            return View(country);
        }

        public IActionResult Delete(string id)
        {
            if (id == null || _context.Country == null)
            {
                return NotFound();
            }

            var country =  _context.Country
                .FirstOrDefault(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

  
        [HttpPost, ActionName("Delete")]
  
        public IActionResult DeleteConfirmed(string id)
        {
            if (_context.Country == null)
            {
                return Problem("Entity set 'MVC1Context.Country'  is null.");
            }
            var country =  _context.Country.Find(id);
            if (country != null)
            {
                _context.Country.Remove(country);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(string id)
        {
          return (_context.Country?.Any(e => e.CountryId == id)).GetValueOrDefault();
        }
    }
}
