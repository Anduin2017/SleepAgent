using System.Reflection;
using Aiursoft.WebTools.Abstractions.Models;
using Anduin.SleepAgent.WebServer.Services;

namespace Anduin.SleepAgent.WebServer;

public class Startup : IWebStartup
{
    public void ConfigureServices(IConfiguration configuration, IWebHostEnvironment environment, IServiceCollection services)
    {
        services.AddSingleton<InMemoryDb>();
        services
            .AddControllersWithViews()
            .AddApplicationPart(Assembly.GetExecutingAssembly());
    }

    public void Configure(WebApplication app)
    {
        app.UseRouting();
        app.MapDefaultControllerRoute();
    }
}