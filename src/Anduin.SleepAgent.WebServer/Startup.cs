using System.Reflection;
using Aiursoft.WebTools.Abstractions.Models;
using Anduin.SleepAgent.WebServer.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Anduin.SleepAgent.WebServer;

public class Startup : IWebStartup
{
    public void ConfigureServices(IConfiguration configuration, IWebHostEnvironment environment, IServiceCollection services)
    {
        services.AddSingleton<InMemoryDb>();
        
        services
            .AddControllersWithViews()
            .AddApplicationPart(Assembly.GetExecutingAssembly())
            .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });
    }

    public void Configure(WebApplication app)
    {
        app.UseRouting();
        app.MapDefaultControllerRoute();
    }
}