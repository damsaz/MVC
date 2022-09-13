using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;
using System;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace MVC1.Controllers
    {
    [Authorize(Roles = "Administrator")]

    public class LPController : Controller
        {

        private readonly MVC1Context _context;

        public LPController(MVC1Context context)
            {
            _context = context;
            }
        public  IActionResult Index()
            {
            var mVC1Context = _context.Person.Include(p => p.Languages);
            return View( mVC1Context);
            }

        public ActionResult Details(int id)
            {
            return View();
            }

        public ActionResult Create()
            {

            return View();
            }

        [HttpPost]
        
        public ActionResult Create(IFormCollection collection)
            {
            try
                {
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }
        [HttpPost]
        public ActionResult Add(int id ,string Languages)
        {
            var person = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id);
            List<Language> lang2 = person.Languages.Where(l => l.Name == Languages).ToList();
            var lang = _context.Language.FirstOrDefault(l => l.Name == Languages);
            if (lang2.Count == 0) {
                person.Languages.Add(lang);
                _context.SaveChanges();
            }
            ViewData["Language"] = new SelectList(_context.Language, "Name", "Name", person.Languages);
            var person2 = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id);
            return View("Edit", person2);
        }
        
            public ActionResult Edit(int id)
            {
            var person = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id); 
           

            ViewData["Language"] = new SelectList(_context.Language, "Name", "Name", person.Languages);
            return View(person);
            
            }

    
        [HttpPost]
       
        public  IActionResult Edit(int id, [Bind("Id,First_name,Last_name,IdCity,Tel")] Person person)
            {
            if (id != person.Id)
                {
                return NotFound();
                }

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
                return RedirectToAction(nameof(Index));
                }
            ViewData["IdCity"] = new SelectList(_context.City, "IdCity", "IdCity", person.IdCity);
            return View(person);
            }

      
        public ActionResult Delete( int IdLanguage, int id)
            {
            var person = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id);
            var lang = _context.Language.FirstOrDefault(l => l.IdLanguage == IdLanguage);
            person.Languages.Remove(lang);
            
            

         _context.SaveChanges();
            var person2 = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id);
            ViewData["Language"] = new SelectList(_context.Language, "Name", "Name", person.Languages);
            return View("Edit", person2);
            }

    
        [HttpPost]
       
        public ActionResult Delete(int id, IFormCollection collection)
            {
            try
                {
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }
        private bool PersonExists(int id)
            {
            return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        [HttpPost, ActionName("Delete")]
   
        public  IActionResult DeleteConfirmed(int id)
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
        }
    }
