using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Library.Models;
using System.Diagnostics;
using System.Reflection;

namespace Library.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private static List<Person> personData = new List<Person>() {
            new Person { Username="mhsa", Password="hamed12345" },
        };

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;

        }

        public IActionResult LogIn()
        {
            return View(personData);
        }

        public IActionResult Form()
        {
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

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SignUp([FromForm] Person person)
        {
            // Check if the username already exists in the list
            var existingUser = personData.FirstOrDefault(u => u.Username == person.Username);

            if (existingUser != null)
            {
                // Username already exists, return an error message or view
                ViewBag.Message = "Username already exists. Please choose a different one.";
                return View(person); // Return the same view with the error message
            }

            // Create a new user
            var user = new Person
            {
                Username = person.Username,
                Password = person.Password,
            };

            // Add the user to the in-memory list
            personData.Add(user);

            // Redirect to a confirmation page or login page
            return RedirectToAction("Users", "LogIn");
        }

        // Optionally, a method to display all users (for testing purposes)
        [HttpGet]
        public IActionResult Users()
        {
            return View(personData);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
