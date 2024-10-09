using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
	public class HomeController : Controller
	{
		[Route("/{bookId?}/{isLogged?}")]
        //http://localhost:5104/29/false?bookId=10&isLogged=true Route data-- here route 
        // http://localhost:5104/?bookId=24&isLogged=true query string 
		//We can also define the parameter with the FormRoute and FromQuery
        public IActionResult Index([FromRoute] int? bookId, [FromQuery] bool? isLogged, [FromQuery]Book book)
		{
			// Bookm id should be provided
			if (bookId.HasValue == false)
			{
				return BadRequest("Book Id is not provided!!");
			}

			//Can not be null or empty
			if (bookId <= 0)
			{
				return BadRequest("Bood Id can not less than or equal to zero!");
			}

			//boodId should be between 1 to 1000
			if (bookId <= 0 || bookId > 1000)
			{
				return BadRequest("bookId should be between 1 to 1000");
			}

            // Check if the 'isLogged' query parameter exists and convert it to boolean
            if (isLogged == false)
            {
				// Respond with a BadRequest if the user is not authenticated
				return StatusCode(401);
                //return Unauthorized("User must be authenticated!");
            }

			return Content($"Book Id: {bookId}, Book: {book}");

			//return File("/sample.pdf", "application/pdf");
			//return new RedirectToActionResult("Books", "Store", new { });

			//
			//return RedirectToAction("Books", "Store", new {id = bookId });


			//Permanent redirection 
			//return new RedirectToActionResult("Books", "Store", new { }, true);

		}
    }
}
