using Anduin.SleepAgent.WebServer.Models.ViewModels;
using Anduin.SleepAgent.WebServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Anduin.SleepAgent.WebServer.Controllers;

[Route("api/[controller]")]
public class MetricsController(InMemoryDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult Document()
    {
        return this.Ok(
        new {
            Document = new Dictionary<string, string>
            {
                { "To get all users list, GET","/api/metrics/all" },
                { "To query a user's data, GET","/api/metrics/query?nick-name=your-nick-name-here" },
                { "To patch a user's data, POST","/api/metrics/send?nick-name=your-nick-name-here" }
            }
        });
    }
    
    [Route("all")]
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(db.GetKeys());
    }
    
    // /api/metrics/query?nick-name=aaaaa
    [Route("query")]
    [HttpGet]
    public IActionResult Get([FromQuery(Name = "nick-name")]string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName))
        {
            return BadRequest();
        }
        
        return Ok(db.Get(nickName));
    }

    // /api/metrics/send?nick-name=aaaaa
    [Route("send")]
    [HttpPost]
    public IActionResult Post([FromQuery(Name = "nick-name")]string nickName, [FromBody]SendViewModel data)
    {
        if (string.IsNullOrWhiteSpace(nickName))
        {
            return BadRequest();
        }
        
        db.Set(nickName, data);
        return Ok();
    }
}