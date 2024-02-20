using Anduin.SleepAgent.WebServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Anduin.SleepAgent.WebServer.Controllers;

[Route("api/[controller]")]
public class MetricController(InMemoryDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(db.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] object data)
    {
        db.Set(data);
        return Ok();
    }
}