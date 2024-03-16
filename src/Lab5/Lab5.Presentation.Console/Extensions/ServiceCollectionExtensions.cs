using Lab5.Presentation.Console.Scenarios.Add;
using Lab5.Presentation.Console.Scenarios.AdminLogin;
using Lab5.Presentation.Console.Scenarios.AdminLogOut;
using Lab5.Presentation.Console.Scenarios.CreatAccount;
using Lab5.Presentation.Console.Scenarios.ShowBalance;
using Lab5.Presentation.Console.Scenarios.ShowHistory;
using Lab5.Presentation.Console.Scenarios.UserLogin;
using Lab5.Presentation.Console.Scenarios.UserLogOut;
using Lab5.Presentation.Console.Scenarios.Withdraw;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ScenarioRunner>();

        serviceCollection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        serviceCollection.AddScoped<IScenarioProvider, AddProvider>();
        serviceCollection.AddScoped<IScenarioProvider, AdminLoginProvider>();
        serviceCollection.AddScoped<IScenarioProvider, CreateAccountProvider>();
        serviceCollection.AddScoped<IScenarioProvider, ShowBalanceProvider>();
        serviceCollection.AddScoped<IScenarioProvider, ShowHistoryProvider>();
        serviceCollection.AddScoped<IScenarioProvider, AdminLogOutProvider>();
        serviceCollection.AddScoped<IScenarioProvider, WithdrawProvider>();
        serviceCollection.AddScoped<IScenarioProvider, UserLogOutProvider>();

        return serviceCollection;
    }
}