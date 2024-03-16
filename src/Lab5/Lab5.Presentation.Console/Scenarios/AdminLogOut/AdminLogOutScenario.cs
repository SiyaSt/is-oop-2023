using Lab5.Application.Contracts.AdminAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminLogOut;

public class AdminLogOutScenario : IScenario
{
    private readonly IAdminAccountService _adminAccountService;

    public AdminLogOutScenario(IAdminAccountService adminAccountService)
    {
        _adminAccountService = adminAccountService;
    }

    public string ScenarioName { get; } = "log out";
    public void Run()
    {
        _adminAccountService.LogOut();
        AnsiConsole.WriteLine("Successful log out");
        AnsiConsole.Ask<string>("Write ok to continue");
    }
}