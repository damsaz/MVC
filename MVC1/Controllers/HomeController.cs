using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC1.Controllers
    {
    public class HomeController : Controller
        {

            readonly RoleManager<IdentityRole> roleManager;
            readonly UserManager<ApplicationUser> userManager;
            public HomeController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
                {
                this.roleManager = roleManager;
                this.userManager = userManager;

                }
            public IActionResult Index()
            {
            //  Data.ApplicationDbContext ss=new Data.ApplicationDbContext();
            // ss.GetPerson();
            if (!String.IsNullOrEmpty(User.Identity.Name)) { 
            var user = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
          
            ViewData["welcomemess"] = "welcome:" +user.FirstName+" "+ user.LastName;
          
                }
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
