using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MVC1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MVC1.Controllers;

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

            People p2 = new People();
            People people = PeopleViewModel.GetPeople();
            List<Person> people2 = (List<Person>)people.people;
            p2.people = people2.Where(people => people.First_name == SearchName).ToList();
             
           
           return View("Index",p2);
            }
        public IActionResult Add(String Tel,String First_name,String Last_name,String Country)
            {

            People p2 = new People();
            People people = PeopleViewModel.GetPeople();
            List<Person> people2 = (List<Person>)people.people;
            int id = people2.Count+1;
            Person person = new(id ,First_name,Last_name,Country,Tel);
            people2.Add(person);  
            p2.people = people2;



            return View("Index", p2);
            }
      
        public IActionResult Delete(String Id)
            {

            People p2 = new People();
            People people = PeopleViewModel.GetPeople();
            List<Person> people2 = (List<Person>)people.people;

            people2 = people2.Where(people => people.Id == int.Parse(Id)).ToList();
          
           



            return View("Index", p2);
            }
        }
    }
