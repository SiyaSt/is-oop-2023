using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.UserAccounts;
using Lab5.Application.Models.Commands;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IUserAccountService _userAccountService;

    public ShowHistoryScenario(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public string ScenarioName { get; } = "show history";
    public void Run()
    {
        CommandResult commandResult = _userAccountService.ShowTransactionHistory();

        if (commandResult is CommandResult.Success<IEnumerable<Command>> result)
        {
            foreach (Command command in result.Value)
            {
                string message = command.CommandName switch
                {
                    CommandName.Add => $"Add amount {command.Value}",
                    CommandName.Withdraw => $"Withdraw amount {command.Value}",
                    _ => throw new ArgumentOutOfRangeException(nameof(command.CommandName)),
                };
                AnsiConsole.WriteLine(message);
            }
        }

        if (commandResult is CommandResult.ErrorExecution errorExecution)
        {
            AnsiConsole.WriteLine(errorExecution.Text);
        }

        AnsiConsole.Ask<string>("Write ok to continue");
    }
}