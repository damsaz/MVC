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

        // GET: Languages
        public async Task<IActionResult> Index()
        {
              return _context.Language != null ? 
                          View(await _context.Language.ToListAsync()) :
                          Problem("Entity set 'MVC1Context.Language'  is null.");
        }

        // GET: Languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.IdLanguage == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLanguage,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLanguage,Name")] Language language)
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
                    await _context.SaveChangesAsync();
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

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.IdLanguage == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Language == null)
            {
                return Problem("Entity set 'MVC1Context.Language'  is null.");
            }
            var language = await _context.Language.FindAsync(id);
            if (language != null)
            {
                _context.Language.Remove(language);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
          return (_context.Language?.Any(e => e.IdLanguage == id)).GetValueOrDefault();
        }
    }
}
