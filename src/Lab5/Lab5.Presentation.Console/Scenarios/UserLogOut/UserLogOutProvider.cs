using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.CurrentAccounts;
using Lab5.Application.Contracts.UserAccounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Presentation.Console.Scenarios.UserLogOut;

public class UserLogOutProvider : IScenarioProvider
{
    private readonly IUserAccountService _userAccountService;
    private readonly ICurrentService _currentUser;

    public UserLogOutProvider(IUserAccountService userAccountService, ICurrentService currentUser)
    {
        _userAccountService = userAccountService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.Roles is null)
        {
            scenario = null;
            return false;
        }

        if (_currentUser.Roles is Roles.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLogOutScenario(_userAccountService);
        return true;
    }
}