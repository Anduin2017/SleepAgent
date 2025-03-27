using Aiursoft.DbTools;
using Microsoft.EntityFrameworkCore;

namespace Anduin.SleepAgent.WebServer.Data;

public class AgentDbContext(DbContextOptions<AgentDbContext> options) : DbContext(options), ICanMigrate
{
    public DbSet<MetricData> MetricData => Set<MetricData>();

    public Task MigrateAsync(CancellationToken cancellationToken)
    {
        return this.Database.MigrateAsync(cancellationToken);
    }

    public Task<bool> CanConnectAsync()
    {
        return Task.FromResult(true);
    }
}
