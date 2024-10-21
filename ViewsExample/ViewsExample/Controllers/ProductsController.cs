using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult All()
        {
            return View();
        }
    }
}
