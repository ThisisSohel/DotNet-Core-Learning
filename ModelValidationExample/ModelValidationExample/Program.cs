using ModelValidationExample.CustomModelBinders;

namespace ModelValidationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configuring PersonBinderProvider.
            builder.Services.AddControllers(option =>
            {
                //option.ModelBinderProviders.Insert(0, new PersonBinderProvider());
            });

            builder.Services.AddControllers().AddXmlSerializerFormatters();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
