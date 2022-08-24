using Microsoft.AspNetCore.Mvc;
using MVC1.Models;
using System.Reflection.Metadata;

namespace MVC1.Controllers
    {
    public class PeopelAjaxController : Controller
        {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;



        public PeopelAjaxController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
            {

            Environment = _environment;
            PeopleManager.filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "jsonfile\\"));

            }
        public IActionResult Index()
            {
            PeopleManager.GetPeople();
            return View();
            }
        public PartialViewResult Load()
            {
            
            return PartialView("_Personlist", PeopleManager.people);
            
            }
        [HttpPost]
        public PartialViewResult Details(int id)
        {
            if (PeopleManager.SearchById(id).people.Count == 1)
                return PartialView("_Person", PeopleManager.SearchById(id).people[0]);
            else
                return PartialView("_Person");

        }
        public PartialViewResult Delete(int Id)
        {
            return PartialView("_Personlist", PeopleManager.Delete(Id));

        }
    }
    }
