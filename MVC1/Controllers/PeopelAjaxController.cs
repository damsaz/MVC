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
            PeopleViewModel.filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "jsonfile\\"));

            }
        public IActionResult Index()
            {
            PeopleViewModel.GetPeople();
            return View();
            }
        public PartialViewResult Load()
            {
            
            return PartialView("_Personlist", PeopleViewModel.people);
            
            }
        [HttpPost]
        public PartialViewResult Details(int id)
        {
            
            return PartialView("_Person", PeopleViewModel.SearchById(id).people[0]);

        }
        public PartialViewResult Delete(int Id)
        {
            return PartialView("_Personlist", PeopleViewModel.Delete(Id));

        }
    }
    }
