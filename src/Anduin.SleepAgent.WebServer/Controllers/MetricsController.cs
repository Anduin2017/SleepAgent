using Anduin.SleepAgent.WebServer.Data;
using Anduin.SleepAgent.WebServer.Models.ViewModels;
using Anduin.SleepAgent.WebServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anduin.SleepAgent.WebServer.Controllers;

[Route("api/[controller]")]
public class MetricsController(AgentDbContext db) : ControllerBase
{
    // /api/metrics
    [HttpGet]
    public IActionResult Document()
    {
        return Ok(
        new {
            Document = new Dictionary<string, string>
            {
                { "To get all users list, GET","/api/metrics/all" },
                { "To query a user's data, GET","/api/metrics/query?nick-name=your-nick-name-here" },
                { "For Prometheus format, GET","/api/metrics/metric?nick-name=your-nick-name-here" },
                { "To patch a user's data, POST","/api/metrics/send" }
            }
        });
    }
    
    // /api/metrics/all
    [Route("all")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var nickNames = await db
            .MetricData
            .Select(m => m.NickName)
            .Distinct()
            .ToListAsync();
        return Ok(nickNames);
    }
    
    // /api/metrics/query?nick-name=nick-name
    [Route("query")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery(Name = "nick-name")]string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName))
        {
            return BadRequest();
        }
        
        var data = await db
            .MetricData
            .Where(m => m.NickName == nickName)
            .OrderByDescending(m => m.RecordTime)
            .FirstOrDefaultAsync();
        
        if (data == null)
        {
            return NotFound();
        }
        
        return Ok(data);
    }
    
    // /api/metrics/metric?nick-name=nick-name
    [Route("metric")]
    [HttpGet]
    public async Task<IActionResult> Metric([FromQuery(Name = "nick-name")]string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName))
        {
            return BadRequest();
        }
        
        var data = await db
            .MetricData
            .Where(m => m.NickName == nickName)
            .OrderByDescending(m => m.RecordTime)
            .FirstOrDefaultAsync();

        if (data == null)
        {
            return NotFound();
        }

        var result = PrometheusFormat.ToPrometheusMetrics(data);
        return Ok(result);
    }

    // /api/metrics/send
    [Route("send")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]SendViewModel data)
    {
        if (string.IsNullOrWhiteSpace(data.User.NickName))
        {
            return BadRequest();
        }

        db.MetricData.Add(data.ToMetricData());
        await db.SaveChangesAsync();
        return Ok();
    }
}