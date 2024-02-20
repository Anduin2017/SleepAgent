using Microsoft.AspNetCore.Mvc;

namespace Anduin.SleepAgent.WebServer.Controllers;

public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        var host = HttpContext.Request.Host;
        var scheme = HttpContext.Request.Scheme;
        var endpoint = $"{scheme}://{host}/api/metrics";
        return Ok($"This is an API server. Please read the document at {endpoint}");
    }
}