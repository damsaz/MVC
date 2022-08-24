using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MVC1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MVC1.Controllers;
using System;
using MVC1.ViewModels;

namespace MVC1.Controllers
    {



    public class PeopleController : Controller
        {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        
     

        public PeopleController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
            {

            Environment = _environment;
            PeopleManager.filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "jsonfile\\"));

            }

        public IActionResult Index()
            {


            var people= PeopleManager.GetPeople();
            return View(people);
            }
        [HttpPost]
        public IActionResult Search(String SearchName)
            {
            return View("Index", PeopleManager.Search(SearchName));
            }
        public IActionResult Add(String Tel,String First_name,String Last_name,String Country)
            {
           
            if (ModelState.IsValid) {
                CreatePersonViewModel.Create(Tel, First_name, Last_name, Country);
            }
            return View("Index", PeopleManager.people);
            }
      
        public IActionResult Delete(String Id)
            {
            return View("Index", PeopleManager.Delete(Id));
            }
        public IActionResult Sort(int Sort)
            {
            PeopleManager.Sort(Sort);
            return View("Index", PeopleManager.people);
            }
        }
    }
