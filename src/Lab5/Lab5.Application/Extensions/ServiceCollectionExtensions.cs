using Lab5.Application.AdminAccounts;
using Lab5.Application.Contracts.AdminAccounts;
using Lab5.Application.Contracts.CurrentAccounts;
using Lab5.Application.Contracts.UserAccounts;
using Lab5.Application.CurrentAccounts;
using Lab5.Application.Models.SystemPasswords;
using Lab5.Application.UserAccounts;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, string systemPassword)
    {
        serviceCollection.AddScoped<IUserAccountService, UserAccountService>();
        serviceCollection.AddScoped<IAdminAccountService, AdminAccountService>();
        serviceCollection.AddScoped<SystemPassword>(x => new SystemPassword(systemPassword));

        serviceCollection.AddScoped<CurrentUserAccountManager>();
        serviceCollection.AddScoped<ICurrentUserAccountService>(
            x => x.GetRequiredService<CurrentUserAccountManager>());
        serviceCollection.AddScoped<CurrentAccountManager>();
        serviceCollection.AddScoped<ICurrentService>(
            x => x.GetRequiredService<CurrentAccountManager>());

        return serviceCollection;
    }
}