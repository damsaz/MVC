using Microsoft.AspNetCore.Mvc;

namespace MVC1.Controllers
    {
    public class HomeController : Controller
        {
        public IActionResult Index()
            {
            Data.ApplicationDbContext ss=new Data.ApplicationDbContext();
            ss.GetPerson();
            return View();
            }

        public IActionResult Privacy()
            {
            return View();
            }
        public IActionResult About()
            {
            return View();
            }
        public IActionResult Contact()
            {
            return View();
            }
        public IActionResult Projects()
            {
            return View();
            }

        }
    }
