using GestorTareas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GestorTareas.Services;

/// <summary>
/// Verifica que la aplicación pueda conectarse a la base de datos.
/// Se expone en el endpoint /health.
/// </summary>
public class BaseDeDatosHealthCheck : IHealthCheck
{
    private readonly IDbContextFactory<TareasDbContext> _factory;

    public BaseDeDatosHealthCheck(IDbContextFactory<TareasDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await using var ctx = await _factory.CreateDbContextAsync(cancellationToken);

            return await ctx.Database.CanConnectAsync(cancellationToken)
                ? HealthCheckResult.Healthy("Base de datos disponible")
                : HealthCheckResult.Unhealthy("No se pudo conectar a la base de datos");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Error al consultar la base de datos", ex);
        }
    }
}
