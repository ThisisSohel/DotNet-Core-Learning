using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
	public class HomeController
	{
		[Route("index")]
		public string Index()
		{
			return "Hello from Index";
		}

		[Route("home")]
		public string Home()
		{
			return "Hello from Home";
		}

		[Route("contact")]
		public string Contact()
		{
			return "Hello from Contact";
		}
	}
}
