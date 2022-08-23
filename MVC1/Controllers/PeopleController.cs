using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MVC1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MVC1.Controllers;
using System;

namespace MVC1.Controllers
    {


    
public class PeopleController : Controller
        {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        
     

        public PeopleController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
            {

            Environment = _environment;
            PeopleViewModel.filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "jsonfile\\"));

            }

        public IActionResult Index()
            {


            var people= PeopleViewModel.GetPeople();
            return View(people);
            }
        [HttpPost]
        public IActionResult Search(String SearchName)
            {
            return View("Index", PeopleViewModel.Search(SearchName));
            }
        public IActionResult Add(String Tel,String First_name,String Last_name,String Country)
            {
           
            if (ModelState.IsValid) {
                CreatePersonViewModel.Create(Tel, First_name, Last_name, Country);
            }
            return View("Index", PeopleViewModel.people);
            }
      
        public PartialViewResult Delete(int Id)
            {
            return PartialView("_Personlist", PeopleViewModel.Delete(Id));
            
            }
        public IActionResult Sort(int Sort)
            {
            PeopleViewModel.Sort(Sort);
            return View("Index", PeopleViewModel.people);
            }
        }
    }
