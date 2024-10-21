using Microsoft.AspNetCore.Mvc;

namespace PartialViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Cities";
            ViewData["ListItem"] = new List<string>()
            {
                "Dhaka",
                "Rajshahi",
                "Rajbari",
                "Sylhet"
            };
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
