using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
    {
    public class Doctor : Controller
        {


        public string grad { get; set; }
        public IActionResult fever()
            {
            return View();
            }
        [HttpPost]
        public IActionResult fever(string grad)
            {

            if (!String.IsNullOrEmpty(grad))
                {
                ViewBag.grad = grad;
                Fevermodel.Degrees = grad;
                ViewBag.Mess = Fevermodel.Check();

                }

            return View("fever");

            }



        }
    }
