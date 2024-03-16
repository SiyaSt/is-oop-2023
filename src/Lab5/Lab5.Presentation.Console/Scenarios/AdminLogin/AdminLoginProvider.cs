using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.AdminAccounts;
using Lab5.Application.Contracts.CurrentAccounts;

namespace Lab5.Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginProvider : IScenarioProvider
{
    private readonly ICurrentService _currentAdmin;
    private readonly IAdminAccountService _adminAccountService;

    public AdminLoginProvider(ICurrentService currentAdmin, IAdminAccountService adminAccountService)
    {
        _adminAccountService = adminAccountService;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAdmin.Roles is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_adminAccountService);
        return true;
    }
}