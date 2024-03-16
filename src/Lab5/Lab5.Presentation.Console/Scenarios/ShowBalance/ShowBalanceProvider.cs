using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserAccounts;

namespace Lab5.Presentation.Console.Scenarios.ShowBalance;

public class ShowBalanceProvider : IScenarioProvider
{
    private readonly IUserAccountService _userAccountService;
    private readonly ICurrentUserAccountService _currentUser;

    public ShowBalanceProvider(IUserAccountService userAccountService, ICurrentUserAccountService currentUser)
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

        scenario = new ShowBalanceScenario(_userAccountService);
        return true;
    }
}