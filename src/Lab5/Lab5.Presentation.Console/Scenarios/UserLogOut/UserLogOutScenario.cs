using Lab5.Application.Contracts.UserAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.UserLogOut;

public class UserLogOutScenario : IScenario
{
    private readonly IUserAccountService _userAccountService;

    public UserLogOutScenario(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public string ScenarioName { get; } = "log out";
    public void Run()
    {
        _userAccountService.LogOut();
        AnsiConsole.WriteLine("Successful log out");
        AnsiConsole.Ask<string>("Write ok to continue");
    }
}