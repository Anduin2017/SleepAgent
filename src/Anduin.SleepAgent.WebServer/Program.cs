using static Aiursoft.WebTools.Extends;

namespace Anduin.SleepAgent.WebServer;

public class Program
{
    public static async Task Main(string[] args)
    {
        await App<Startup>(args).RunAsync();
    }
}