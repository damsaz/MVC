using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.ViewModels;

namespace MVC1.Controllers
{
    public class PeopleEFController : Controller
    {
        private readonly MVC1Context _context;

        public PeopleEFController(MVC1Context context)
        {
            _context = context;
        }

        // GET: PeopleEF
        public async Task<IActionResult> Index()
        {
              return _context.Person != null ? 
                          View(await _context.Person.ToListAsync()) :
                          Problem("Entity set 'MVC1Context.PeopleViewModel'  is null.");
        }

        // GET: PeopleEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var peopleViewModel = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleViewModel == null)
            {
                return NotFound();
            }

            return View(peopleViewModel);
        }

        // GET: PeopleEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeopleEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] PeopleViewModel peopleViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peopleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peopleViewModel);
        }

        // GET: PeopleEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var peopleViewModel = await _context.Person.FindAsync(id);
            if (peopleViewModel == null)
            {
                return NotFound();
            }
            return View(peopleViewModel);
        }

        // POST: PeopleEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] PeopleViewModel peopleViewModel)
        {
            if (id != peopleViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peopleViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleViewModelExists(peopleViewModel.Id))
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
            return View(peopleViewModel);
        }

        // GET: PeopleEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var peopleViewModel = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleViewModel == null)
            {
                return NotFound();
            }

            return View(peopleViewModel);
        }

        // POST: PeopleEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'MVC1Context.PeopleViewModel'  is null.");
            }
            var peopleViewModel = await _context.Person.FindAsync(id);
            if (peopleViewModel != null)
            {
                _context.Person.Remove(peopleViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleViewModelExists(int id)
        {
          return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
