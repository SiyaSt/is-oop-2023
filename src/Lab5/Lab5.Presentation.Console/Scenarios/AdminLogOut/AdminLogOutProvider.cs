using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.AdminAccounts;
using Lab5.Application.Contracts.CurrentAccounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Presentation.Console.Scenarios.AdminLogOut;

public class AdminLogOutProvider : IScenarioProvider
{
    private readonly ICurrentService _currentAdmin;
    private readonly IAdminAccountService _adminAccountService;

    public AdminLogOutProvider(ICurrentService currentAdmin, IAdminAccountService adminAccountService)
    {
        _adminAccountService = adminAccountService;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAdmin.Roles is null)
        {
            scenario = null;
            return false;
        }

        if (_currentAdmin.Roles is Roles.User)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLogOutScenario(_adminAccountService);
        return true;
    }
}