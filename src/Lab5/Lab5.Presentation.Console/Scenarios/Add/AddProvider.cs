using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserAccounts;

namespace Lab5.Presentation.Console.Scenarios.Add;

public class AddProvider : IScenarioProvider
{
    private readonly IUserAccountService _userAccountService;
    private readonly ICurrentUserAccountService _currentUser;

    public AddProvider(IUserAccountService userAccountService, ICurrentUserAccountService currentUser)
    {
        _userAccountService = userAccountService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AddScenario(_userAccountService);
        return true;
    }
}