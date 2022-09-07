using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;
using System;

namespace MVC1.Controllers
    {
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

        // GET: LPController/Edit/5
        public ActionResult Edit(int id)
            {
            var person = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id); 
           
           // var person = mVC1Context.Person.Find(id);
           // ViewData["IdLanguage"] = new SelectList(_context.Language, "Name", "Name");
             //  ViewData["IdLanguage"] = new List(person.Languages, "Name", "Name");
            return View(person);
            
            }

        // POST: LPController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,First_name,Last_name,IdCity,Tel")] Person person)
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
                    await _context.SaveChangesAsync();
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

        // GET: LPController/Delete/5
        public ActionResult Delete([Bind("IdLanguage,Name")] Language Language, int id)
            {
            var person = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id);
            person.Languages.Remove(Language);
            
            

         _context.SaveChanges();
            var person2 = _context.Person.Include(p => p.Languages).FirstOrDefault(e => e.Id == id);
            return View("Edit", person2);
            }

        // POST: LPController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            if (_context.Person == null)
                {
                return Problem("Entity set 'MVC1Context.Person'  is null.");
                }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
                {
                _context.Person.Remove(person);
                }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
        }
    }
