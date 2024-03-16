using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.CurrentAccounts;
using Lab5.Application.Contracts.UserAccounts;

namespace Lab5.Presentation.Console.Scenarios.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserAccountService _userAccountService;
    private readonly ICurrentService _currentUser;

    public UserLoginScenarioProvider(IUserAccountService userAccountService, ICurrentService currentUser)
    {
        _userAccountService = userAccountService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.Roles is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLoginScenario(_userAccountService);
        return true;
    }
}