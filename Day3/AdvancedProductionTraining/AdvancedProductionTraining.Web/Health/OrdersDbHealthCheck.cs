using AdvancedProductionTraining.Web.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AdvancedProductionTraining.Web.Health;

public sealed class OrdersDbHealthCheck : IHealthCheck
{
    private readonly OrdersDbContext _db;

    public OrdersDbHealthCheck(OrdersDbContext db)
    {
        _db = db;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var canConnect = await _db.Database.CanConnectAsync(cancellationToken);
        return canConnect
            ? HealthCheckResult.Healthy("Database connection is healthy.")
            : HealthCheckResult.Unhealthy("Cannot connect to orders database.");
    }
}
