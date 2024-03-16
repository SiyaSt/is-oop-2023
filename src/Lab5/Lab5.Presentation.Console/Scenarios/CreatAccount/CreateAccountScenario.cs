using Lab5.Application.Contracts.AdminAccounts;
using Lab5.Application.Contracts.Results;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreatAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminAccountService _adminAccountService;

    public CreateAccountScenario(IAdminAccountService adminAccountService)
    {
        _adminAccountService = adminAccountService;
    }

    public string ScenarioName { get; } = "create account";
    public void Run()
    {
        int id = AnsiConsole.Ask<int>("Enter new account id");
        int pin = AnsiConsole.Ask<int>("Enter new pin");
        decimal value = AnsiConsole.Ask<decimal>("Enter amount money to add");

        CommandResult commandResult = _adminAccountService.CreateAccount(id, pin, value);
        string message = commandResult switch
        {
            CommandResult.Success<string> result => result.Value,
            CommandResult.ErrorExecution result => result.Text,
            _ => throw new ArgumentOutOfRangeException(nameof(commandResult)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Write ok to continue");
    }
}