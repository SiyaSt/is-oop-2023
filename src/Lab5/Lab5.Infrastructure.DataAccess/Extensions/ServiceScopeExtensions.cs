using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceScopeExtensions
{
    public static void UseInfrastructureDataAccess(this IServiceScope serviceScope)
    {
        serviceScope.UsePlatformMigrationsAsync(default).GetAwaiter().GetResult();
    }
}