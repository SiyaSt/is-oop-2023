using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.UserAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IUserAccountService _userAccountService;

    public WithdrawScenario(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public string ScenarioName { get; } = "withdraw";
    public void Run()
    {
        decimal value = AnsiConsole.Ask<decimal>("Enter amount to withdraw");

        CommandResult commandResult = _userAccountService.WithdrawMoney(value);
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