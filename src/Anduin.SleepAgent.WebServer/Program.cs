using System.Diagnostics.CodeAnalysis;
using Aiursoft.DbTools;
using Anduin.SleepAgent.WebServer.Data;
using static Aiursoft.WebTools.Extends;

namespace Anduin.SleepAgent.WebServer;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task Main(string[] args)
    {
        var app = await AppAsync<Startup>(args);
        await app.UpdateDbAsync<AgentDbContext>(UpdateMode.MigrateThenUse);
        await app.RunAsync();
    }
}