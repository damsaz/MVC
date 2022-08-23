using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

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
            return View();
            }
        public JsonResult Load()
            {
            PeopleViewModel.GetPeople();
            List<Person> people2 = (List<Person>)PeopleViewModel.people.people;
            return  new JsonResult(Ok(people2));
            }
        }
    }
