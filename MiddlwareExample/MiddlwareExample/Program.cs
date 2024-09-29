using MiddlwareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// Middleware1
app.Use(async (HttpContext context, RequestDelegate next) =>
{

    await context.Response.WriteAsync("Hello Middleware1 - ");
    await next(context); // Passes control to the next middleware
});

// Middleware2
app.UseMiddleware<MyCustomMiddleware>();

//Now I am using extention method to invoke the custom middleware
//app.UseMyCustomMiddleware();

// Middleware3 (Terminal middleware)
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync(" Middleware3");
});

app.Run();
