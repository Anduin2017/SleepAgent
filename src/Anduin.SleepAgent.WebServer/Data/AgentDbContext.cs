using Microsoft.EntityFrameworkCore;

namespace Anduin.SleepAgent.WebServer.Data;

public class AgentDbContext(DbContextOptions<AgentDbContext> options) : DbContext(options)
{
    public DbSet<MetricData> MetricData => Set<MetricData>();
}