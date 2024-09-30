namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //use routing befor enable routing...
            //app.Use(async (context, next) =>
            //{
            //    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
            //    if (endpoint != null)
            //    {
            //        await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
            //    }
            //    await next(context);
            //});

            //enable routing 
            app.UseRouting();

            //use routing after enable routing...
            //app.Use(async (context, next) =>
            //{
            //    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
            //    if (endpoint != null)
            //    {
            //       await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
            //    }
            //    await next(context);
            //});

            //enable endpoint
            app.UseEndpoints(endpoints =>
            {
                //if I use MapGet insteed of Map only, it will be only responsible for the GET request
                endpoints.MapGet("map1", async (context) =>
                {
                    await context.Response.WriteAsync("<h1>Hello from Map1 <h1>");
                });

                //if I use MapPost insteed of Map only, it will be only responsible for the POST request
                endpoints.MapPost("map2", async (context) =>
                {
                    await context.Response.WriteAsync("Hello from Map2 ");
                    
                });

                endpoints.Map("files/{filename}.{extention}", async (context) =>
                {
                    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
                    string? fileExtention = Convert.ToString(context.Request.RouteValues["extention"]);
                    await context.Response.WriteAsync($"In File form {fileName}/{fileExtention}");
                });

                endpoints.Map("employee/profile/{empId}", async (context) =>
                {
                    string? empId = Convert.ToString(context.Request.RouteValues["empId"]);
                    await context.Response.WriteAsync($"I am employee - {empId}");
                });

                // Default parameter
                endpoints.Map("product/details/{Id?}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("Id"))
                    {
                        int? id = Convert.ToInt32(context.Request.RouteValues["Id"]);
                        await context.Response.WriteAsync($"Product id is - {id}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Product id is no provided!");
                    }
                });
            });

            //making default endpoint
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Request received at: {context.Request.Path} and the status code is : {context.Response.StatusCode}");
            });
            app.Run();
        }
    }
}
