using Scalar.AspNetCore;
using the_webapi.Middlewares;
using the_webapi.Repository;
using the_webapi.Services;

namespace the_webapi.Configurations
{
    public static class AppConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }

        public static void AddDevStuff(this WebApplication app)
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options => {
                options.Title = "Person API";
                options.Theme = ScalarTheme.BluePlanet;
            });
        }

        public static void AddMyMiddleware(this WebApplication app)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}