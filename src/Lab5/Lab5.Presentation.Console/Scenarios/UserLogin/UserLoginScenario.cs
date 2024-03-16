using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.UserAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.UserLogin;

public class UserLoginScenario : IScenario
{
    private readonly IUserAccountService _userAccountService;

    public UserLoginScenario(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public string ScenarioName { get; } = "user";

    public void Run()
    {
        long username = AnsiConsole.Ask<long>("Enter your account id");
        int pin = AnsiConsole.Ask<int>("Enter your pin code");

        LoginResult result = _userAccountService.Login(username, pin);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.ErrorPin => "Error pin",
            LoginResult.NotFound => "Account not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Write ok to continue");
    }
}