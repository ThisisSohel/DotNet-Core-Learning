using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing.Constraints;

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

                // Default parameter and optional parameter! min constraint will accept the matched values
                endpoints.Map("product/details/{Id:Range(2, 6)}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("Id"))
                    {
                        int? id = Convert.ToInt32(context.Request.RouteValues["Id"]);
                        await context.Response.WriteAsync($"Product id is - {id}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Product id is not provided!");
                    }
                });

                //Ex: the route constraint is datetime
                endpoints.Map("daily-product-report/{reportDate:datetime}", async (context) =>
                {
                    DateTime dateTime = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);
                    await context.Response.WriteAsync($"Daily Product Report Date: {dateTime}");
                });

                //Ex: the route constraint is Guid
                endpoints.Map("cities/{guidId:guid}", async (context) =>
                {
                    Guid guid = Guid.Parse(Convert.ToString(context.Request.RouteValues["guidId"]));
                    await context.Response.WriteAsync($"The city Guid id is: {guid}");
                });

                // Using the 'minlength' constraint to enforce a minimum length of 3 characters
                endpoints.Map("employee/profile/{empName:length(3,6)=sohel}", async context =>
                {
                    string? name = Convert.ToString(context.Request.RouteValues["empName"]);
                    await context.Response.WriteAsync($"The employee name is - {name}");
                });

                // Route that uses the 'alpha' constraint to allow only alphabetic characters for empName
                endpoints.Map("employee/Alphaname/{empName:alpha}", async context =>
                {
                    string? name = Convert.ToString(context.Request.RouteValues["empName"]);
                    await context.Response.WriteAsync($"The employee name is with Alpha - {name}");
                });

                // Route that uses the 'regex' constraint to allow alphabetic characters (A-Z, a-z) and spaces
                endpoints.Map("employee/Regname/{empName:regex(^[a-zA-Z\\s]+$)}", async context =>
                {
                    string? name = Convert.ToString(context.Request.RouteValues["empName"]);
                    await context.Response.WriteAsync($"The employee name is - {name}");
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
