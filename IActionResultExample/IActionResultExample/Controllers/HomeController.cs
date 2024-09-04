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
				return Content("Book Id is not provided!!");
			}

			//Can not be null or empty
			if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
			{
				return Content("Bood Id can not null or empty");
			}

			//boodId should be between 1 to 1000
			int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookId"]);

			if (bookId <= 0 || bookId > 1000)
			{
				return Content("boodId should be between 1 to 1000");
			}
			return Content("Everything is okay");

		}
	}
}
