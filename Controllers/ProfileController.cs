using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Diagnostics;

namespace Library.Controllers
{
    public class ProfileController : Controller
    {
     
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ProfileForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileForm([FromForm] Person person)
        {
            Person.personData.Clear();

            var user = new Person
            {
                Firstname= person.Firstname,
                Lastname= person.Lastname,
                Username = person.Username,
                Email = person.Email,
                Password = person.Password,
            };

            Person.personData.Add(user);
            return RedirectToAction("HomePage", "MainPage");
        }
    }
}
