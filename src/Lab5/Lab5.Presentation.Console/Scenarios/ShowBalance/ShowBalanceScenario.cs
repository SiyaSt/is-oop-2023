using System.Globalization;
using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.UserAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowBalance;

public class ShowBalanceScenario : IScenario
{
    private readonly IUserAccountService _userAccountService;

    public ShowBalanceScenario(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public string ScenarioName { get; } = "show balance";
    public void Run()
    {
        CommandResult commandResult = _userAccountService.ShowBalance();

        if (commandResult is CommandResult.Success<decimal> result)
        {
            AnsiConsole.WriteLine($"Balance {result.Value.ToString(CultureInfo.InvariantCulture)}");
        }

        if (commandResult is CommandResult.ErrorExecution errorExecution)
        {
            AnsiConsole.WriteLine(errorExecution.Text);
        }

        AnsiConsole.Ask<string>("Write ok to continue");
    }
}