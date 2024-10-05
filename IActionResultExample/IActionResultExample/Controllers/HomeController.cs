using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
	public class HomeController : Controller
	{
		[Route("/")]
		public IActionResult Index()
		{
			// Bookm id should be provided
			if (!Request.Query.ContainsKey("bookId"))
			{
				return BadRequest("Book Id is not provided!!");
			}

			//Can not be null or empty
			if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
			{
				return BadRequest("Bood Id can not null or empty");
			}

			//boodId should be between 1 to 1000
			int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookId"]);

			if (bookId <= 0 || bookId > 1000)
			{
				return BadRequest("bookId should be between 1 to 1000");
			}

            // Check if the 'isLogged' query parameter exists and convert it to boolean
            if (!bool.TryParse(Request.Query["isLogged"], out bool isLogged) || !isLogged)
            {
                // Respond with a BadRequest if the user is not authenticated
                return Unauthorized("User must be authenticated!");
            }

			//return File("/sample.pdf", "application/pdf");
			//return new RedirectToActionResult("Books", "Store", new { });

            //
            return RedirectToAction("Books", "Store", new {id = bookId });


            //Permanent redirection 
            //return new RedirectToActionResult("Books", "Store", new { }, true);

        }
    }
}
