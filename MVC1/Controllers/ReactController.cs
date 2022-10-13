using System;
using System.Collections;
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
using Newtonsoft.Json.Linq;
using NuGet.Protocol;

namespace MVC1.Controllers
    {

    // [Authorize(Roles = "Administrator,User")]

    public class React : Controller
        {
        private readonly MVC1Context _context;

        public React(MVC1Context context)
            {
            _context = context;
            }

       // public IEnumerable<WeatherForecast> Get()
          //  {
         //   return Enumerable.Range(1, 5).Select(index => new WeatherForecast
         //       {
           //     Date = DateTime.Now.AddDays(index),
          //      TemperatureC = Random.Shared.Next(-20, 55),
                //   Summary = Summaries[Random.Shared.Next(Summaries.Length)]
          //      })
          //  .ToArray();
           // }
        public IEnumerable<MVC1.Models.Person> Index()
            {
            var mVC1Context = _context.Person.Include(p => p.city);
            List<Person> values= mVC1Context.ToList();
            return values.ToArray();
            }


        public IEnumerable<Person> Details(int? id)
            {
            if (id == null || _context.Person == null)
                {
                return null;
                }

            var person = _context.Person
                .Include(p => p.city)
                .FirstOrDefault(m => m.Id == id);
            if (person == null)
                {
                return null;
            }
            List<Person> values =new List<Person>();
            values.Add(person);
            return values.ToArray();
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
            if (ModelState.IsValid)
                {
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

            var person = _context.Person.Find(id);
            if (person == null)
                {
                return NotFound();
                }
            ViewData["IdCity"] = new SelectList(_context.City, "CityName", "CityName", _context.City.FirstOrDefault(c => c.IdCity == person.IdCity).CityName);
            return View(person);
            }

        [HttpPost]

        public IEnumerable Edit(int id,[Bind("Id,First_name,Last_name,IdCity,Tel")] Person person,string Languages)
            {

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
                      
                        }
                    else
                        {
                        throw;
                        }
                    }
                }
          

            yield return person;
            }
        [HttpGet]
        public IEnumerable Cityname()
            {
            return _context.City;
            }
        public IEnumerable CountryList()
            {
            return _context.Country.Include(c => c.City);


            }
        public IEnumerable LList()
            {
            return _context.Language;


            }
        public string Delete(int? id)
            {
            if (id == null || _context.Person == null)
                {
                return "NotFound";
                }

            var person = _context.Person
                .Include(p => p.city)
                .FirstOrDefault(m => m.Id == id);
            if (person == null)
                {
                return "NotFound";
                }
            if (person != null)
                {
                _context.Person.Remove(person);
                }

            _context.SaveChanges();
            return person.First_name + "Dleted";
            }


       
        private bool PersonExists(int id)
            {
            return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }
    }
