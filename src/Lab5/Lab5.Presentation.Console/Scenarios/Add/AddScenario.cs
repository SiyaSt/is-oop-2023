using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.UserAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Add;

public class AddScenario : IScenario
{
    private readonly IUserAccountService _userAccountService;

    public AddScenario(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public string ScenarioName { get; } = "add";
    public void Run()
    {
        decimal value = AnsiConsole.Ask<decimal>("Enter amount to add");

        CommandResult commandResult = _userAccountService.AddMoney(value);
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