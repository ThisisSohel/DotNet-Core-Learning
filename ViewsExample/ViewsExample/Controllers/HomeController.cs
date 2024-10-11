using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            //return Content("Index");
            //return new ViewResult()
            //{
            //    ViewName = "Home",
            //};
            return View();
        }
    }
}
