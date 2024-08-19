using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Diagnostics;

namespace Library.Controllers
{
    public class LogInController : Controller
    {

        private readonly ILogger<LogInController> _logger;
        private static List<Person> personData = new List<Person>() {
            new Person { Username="mhsa", Password="hamed" },
        };

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;

        }

        public IActionResult LogIn()
        {
            return View(personData);
        }

        public IActionResult Form() { 
            return View(); 
        }
       
        
        [HttpPost]
        public IActionResult Form([FromForm] Person person)
        {
            
                // Check if the form data exists in the list
                var match = personData.FirstOrDefault(x => x.Username == person.Username && x.Password == person.Password);

                if (match != null)
                {
                return RedirectToAction("Index", "Home");
            }
            else
                {
                    ViewBag.Message = "No match found.";
                return View(person);
            }


            
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
