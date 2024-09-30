using System.Runtime.CompilerServices;

namespace MiddlwareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync(" My Custom Middleware starts ....\n ");
            await next(context);
            await context.Response.WriteAsync(" My Custom Middleware ends /n");

        }
    }

    public static class CustomMiddlewareExtention
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
