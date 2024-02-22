using System.Reflection;
using Aiursoft.DbTools.Sqlite;
using Aiursoft.WebTools.Abstractions.Models;
using Anduin.SleepAgent.WebServer.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Anduin.SleepAgent.WebServer;

public class Startup : IWebStartup
{
    public void ConfigureServices(IConfiguration configuration, IWebHostEnvironment environment, IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddAiurSqliteWithCache<AgentDbContext>(connectionString);
        
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