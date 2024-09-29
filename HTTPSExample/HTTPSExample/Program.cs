using Microsoft.Extensions.Primitives;
using System;

namespace HTTPSExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World! GET");
            //app.MapPost("/", () => "Hello World! POST");
            //app.MapPut("/", () => "Hello World! PUT");
            //app.MapPatch("/", () => "Hello World! PATCH");

            app.Run(async (HttpContext context) =>
            {
                context.Response.Headers["MyKey"] = "MyValue";
                context.Response.Headers["Server"] = "MyServer";
                context.Response.Headers["Content-Type"] = "text/html";
                context.Response.StatusCode = 500;

                //Finding the path and method of HTTP request.
                string path = context.Request.Path;
                string method = context.Request.Method;
                if (method == "GET")
                {
                    await context.Response.WriteAsync("<h1>Hello Bangladesh<h1>");
                }
                else
                {
                    await context.Response.WriteAsync("<h1>Hello World<h1>");
                }

                //Now findng the Id of HTTP query string

                if (context.Request.Method == "GET")
                {
                    //Finding the id from the query string 
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        string? id = context.Request.Query["id"];
                        await context.Response.WriteAsync($"Id = {id}, ");
                    }

                    //Finding the name from the query string 
                    if (context.Request.Query.ContainsKey("name"))
                    {
                        string? name = context.Request.Query["name"];
                        await context.Response.WriteAsync($"Name = {name}");
                    }
                }
                await context.Response.WriteAsync($"<h2>{path}<h2>");
                await context.Response.WriteAsync($"<h2>{method}<h2>");

                //Now working on the POST request by the Postman

                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                Dictionary<string, StringValues> dicQuery = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                if (dicQuery.ContainsKey("firstName"))
                {
                    string? firstname = dicQuery["firstName"][0];
                    await context.Response.WriteAsync($"{firstname}");

                    foreach (var fName in dicQuery["firstName"])
                    {
                        await context.Response.WriteAsync($"{fName}");
                    }
                }


                // Doing assignments 
                if (context.Request.Method == "GET" && context.Request.Path == "/")
                {
                    int firstNumber = 0, secondNumber = 0;
                    string? operation = null;
                    long? result = null;

                    //read 'firstNumber' if submitted in the request body
                    if (context.Request.Query.ContainsKey("firstNumber"))
                    {
                        string firstNumberString = context.Request.Query["firstNumber"][0];
                        if (!string.IsNullOrEmpty(firstNumberString))
                        {
                            firstNumber = Convert.ToInt32(firstNumberString);
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
                        }
                    }
                    else
                    {
                        if (context.Response.StatusCode == 200)
                            context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
                    }

                    //read 'secondNumber' if submitted in the request body
                    if (context.Request.Query.ContainsKey("secondNumber"))
                    {
                        string secondNumberString = context.Request.Query["secondNumber"][0];
                        if (!string.IsNullOrEmpty(secondNumberString))
                        {
                            secondNumber = Convert.ToInt32(context.Request.Query["secondNumber"][0]);
                        }
                        else
                        {
                            if (context.Response.StatusCode == 200)
                                context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
                        }
                    }
                    else
                    {
                        if (context.Response.StatusCode == 200)
                            context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
                    }

                    //read 'operation' if submitted in the request body
                    if (context.Request.Query.ContainsKey("operation"))
                    {
                        operation = Convert.ToString(context.Request.Query["operation"][0]);

                        //perform the calculation based on the value of "operation"
                        switch (operation)
                        {
                            case "add": result = firstNumber + secondNumber; break;
                            case "subtract": result = firstNumber - secondNumber; break;
                            case "multiply": result = firstNumber * secondNumber; break;
                            case "divide": result = (secondNumber != 0) ? firstNumber / secondNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
                            case "mod": result = (secondNumber != 0) ? firstNumber % secondNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
                        }

                        //If no case matched above, the "result" remains as 'null'
                        if (result.HasValue)
                        {
                            await context.Response.WriteAsync(result.Value.ToString());
                        }

                        //if invalid value is submitted for "operation" parameter
                        else
                        {
                            if (context.Response.StatusCode == 200)
                                context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input for 'operation'\n");
                        }

                    } //end of "of ContainsKey("operation")

                    //if the "operation" parameter is submitted from the client
                    else
                    {
                        if (context.Response.StatusCode == 200)
                            context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid input for 'operation'\n");
                    }
                }
            });
            app.Run();
        }
    }
}
