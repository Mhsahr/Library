using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }

    }
}
