using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly MVC1Context _context;

        public LanguagesController(MVC1Context context)
        {
            _context = context;
        }

      
        public IActionResult Index()
        {
              return _context.Language != null ? 
                          View( _context.Language.ToList()) :
                          Problem("Entity set 'MVC1Context.Language'  is null.");
        }

      
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language =  _context.Language
                .FirstOrDefault(m => m.IdLanguage == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
 
        public IActionResult Create([Bind("IdLanguage,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

     
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language =  _context.Language.Find(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }


        [HttpPost]
     
        public IActionResult Edit(int id, [Bind("IdLanguage,Name")] Language language)
        {
            if (id != language.IdLanguage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(language);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.IdLanguage))
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
            return View(language);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language =  _context.Language
                .FirstOrDefault(m => m.IdLanguage == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

    
        [HttpPost, ActionName("Delete")]
     
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Language == null)
            {
                return Problem("Entity set 'MVC1Context.Language'  is null.");
            }
            var language =  _context.Language.Find(id);
            if (language != null)
            {
                _context.Language.Remove(language);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
          return (_context.Language?.Any(e => e.IdLanguage == id)).GetValueOrDefault();
        }
    }
}
