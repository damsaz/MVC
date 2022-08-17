using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
    {
    public class GuessingGameController : Controller
        {
        private CookieOptions options;

        public IActionResult Game()
            {
            BestPlayerLOad();
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Nummer")))
                {
                GuessingGame.GuessNummer = GuessingGame.GenerateNumber();
                HttpContext.Session.SetString("Nummer", GuessingGame.GuessNummer.ToString() );
                
                }
            else
                {
                GuessingGame.GuessNummer =int.Parse( HttpContext.Session.GetString("Nummer"));
                }
          
            return View();
            }

        private void BestPlayerLOad()
            {
            
            if (!String.IsNullOrEmpty(HttpContext.Request.Cookies["BestPlay"]))
                {

                ViewBag.Best= "The best record:" +HttpContext.Request.Cookies["BestPlay"];

                }
            else
            ViewBag.Best = "";
            }

        [HttpPost]

        public IActionResult Game(string playerGuess)
            {
            ViewBag.PlayerGuess = playerGuess;  
            ViewBag.Message = GuessingGame.Game(playerGuess);
            if (GuessingGame.GameOver)
                {
                PlayAdd(GuessingGame.Count);
                GuessingGame.Count = 0;
                GuessingGame.GuessNummer = GuessingGame.GenerateNumber();
                HttpContext.Session.SetString("Nummer", GuessingGame.GuessNummer.ToString());
                }
            else
                {
                GuessingGame.Count++;
                ViewBag.Message = ViewBag.Message + " Number of attempts: " +  GuessingGame.Count;
                }
            BestPlayerLOad();
            return View();
            }

        private void PlayAdd(int count)
            {
            
            options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            if (!String.IsNullOrEmpty(HttpContext.Request.Cookies["BestPlay"])) { 
                if (int.Parse(HttpContext.Request.Cookies["BestPlay"]) > count)
                   HttpContext.Response.Cookies.Append("BestPlay",count.ToString(), options);
            }
            else
                HttpContext.Response.Cookies.Append("BestPlay", count.ToString(), options);
            }
        }
    }
