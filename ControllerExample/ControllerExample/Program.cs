using ControllerExample.Controllers;

namespace ControllerExample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();	//Adding all the controllers as services.
			var app = builder.Build();

			app.MapControllers(); //Mapping all the controllers
			app.Run();
		}
	}
}
