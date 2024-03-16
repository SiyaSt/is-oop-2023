using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserAccounts;

namespace Lab5.Presentation.Console.Scenarios.ShowHistory;

public class ShowHistoryProvider : IScenarioProvider
{
    private readonly IUserAccountService _userAccountService;
    private readonly ICurrentUserAccountService _currentUser;

    public ShowHistoryProvider(IUserAccountService userAccountService, ICurrentUserAccountService currentUser)
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

        scenario = new ShowHistoryScenario(_userAccountService);
        return true;
    }
}