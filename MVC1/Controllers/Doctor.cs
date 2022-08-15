using Microsoft.AspNetCore.Mvc;

namespace MVC1.Controllers
    {
    public class Doctor : Controller
        {
        public IActionResult Index()
            {
            return View();
            }
        }
    }
