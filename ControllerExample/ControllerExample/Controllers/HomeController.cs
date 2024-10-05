using Microsoft.AspNetCore.Mvc;
using ControllerExample.Models;

namespace ControllerExample.Controllers
{
	[Controller] //It also work if we use a Controller attribute on Controller class. On the other hand, we can also use both attribute and Controller suffix with Controller name!
	public class HomeController : Controller
	{
		[Route("index")]
		public string Index()
		{
			return "Hello from Index";
		}

		[Route("hello")]
		[Route("/")]
		public ContentResult Hello()
		{
			string htmlContent = "<html><body><h1>Hello, Welcome to Dot Net Tutorials</h1></body></html>";
			return Content(htmlContent, "text/html");
			//return new ContentResult()
			//{
			//	Content = htmlContent,
			//	ContentType = "text/html"
			//};

			//string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><item>Hello Dot Net Tutorials</item></data>";
			//return new ContentResult()
			//{
			//	Content = xmlContent,
			//	ContentType = "application/xml"
			//};
		}

		[Route("contact")]
		public string Contact()
		{
			return "Hello from Contact";
		}

		[Route("person")]
		public JsonResult Pesron()
		{
			Person person = new Person()
			{
				Id = Guid.NewGuid(),
				FirstName = "Sohel",
				LasttName = "Rana",
				Age = 24
			};
			//return new JsonResult(person);	
			return Json(person);	//Real world use
		}

		[Route("file-Download")]
		public VirtualFileResult FileContentResult()
		{
			return new VirtualFileResult("/Cv of Sohel Rana.pdf","application/pdf");
		}

		[Route("file-Download2")]
		//Using PhysicalFileResult we find the file even if it is not in the project directory! 
		public PhysicalFileResult FileContentResult2()
		{
			return new PhysicalFileResult(@"C:\\Users\\hp\\Desktop\\Cv of Sohel Rana.pdf", "application/pdf");
		}

		//Reading a file from a specific file from the computer.
		[Route("file-download3")]
		public IActionResult PhysicalFileResult()
		{
			byte[] bytes =  System.IO.File.ReadAllBytes("@C:\\Users\\hp\\Desktop\\JobApplicationThings");
			return new FileContentResult(bytes, "application/pdf");
		}
	}
}
