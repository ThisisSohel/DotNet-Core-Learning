namespace StaticFilesExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();


            app.Map("/", async (context) =>
            {
                await context.Response.WriteAsync("Hello");
            });

            app.Run();
        }
    }
}
