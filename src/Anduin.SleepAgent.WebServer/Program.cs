using System.Diagnostics.CodeAnalysis;
using static Aiursoft.WebTools.Extends;

namespace Anduin.SleepAgent.WebServer;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task Main(string[] args)
    {
        await App<Startup>(args).RunAsync();
    }
}