using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

    }
}