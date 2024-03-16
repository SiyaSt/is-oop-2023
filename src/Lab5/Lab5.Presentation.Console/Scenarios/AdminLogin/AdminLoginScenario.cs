using Lab5.Application.Contracts.AdminAccounts;
using Lab5.Application.Contracts.Results;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminAccountService _adminAccountService;

    public AdminLoginScenario(IAdminAccountService adminAccountService)
    {
        _adminAccountService = adminAccountService;
    }

    public string ScenarioName { get; } = "admin";
    public void Run()
    {
        string systemPassword = AnsiConsole.Ask<string>("Enter system password");
        LoginResult loginResult = _adminAccountService.Login(systemPassword);

        if (loginResult is LoginResult.Success)
        {
            AnsiConsole.WriteLine("Successful login");
        }

        AnsiConsole.Ask<string>("Write ok to continue");
    }
}