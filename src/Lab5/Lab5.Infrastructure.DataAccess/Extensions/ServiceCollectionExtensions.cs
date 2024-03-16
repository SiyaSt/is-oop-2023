using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Abstraction.Repositories;
using Lab5.Infrastructure.DataAccess.Plugins;
using Lab5.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection serviceCollection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        serviceCollection.AddPlatformPostgres(builder => builder.Configure(configuration));
        serviceCollection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        serviceCollection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        serviceCollection.AddScoped<IUserAccountRepository, UserAccountRepository>();
        serviceCollection.AddScoped<IAdminAccountRepository, AdminAccountRepository>();
        serviceCollection.AddScoped<ICommandRepository, CommandRepository>();

        return serviceCollection;
    }
}