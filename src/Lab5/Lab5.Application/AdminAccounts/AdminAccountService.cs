using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Contracts.AdminAccounts;
using Lab5.Application.Contracts.Results;
using Lab5.Application.CurrentAccounts;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.SystemPasswords;

namespace Lab5.Application.AdminAccounts;

public class AdminAccountService : IAdminAccountService
{
    private readonly IAdminAccountRepository _adminAccountRepository;
    private readonly CurrentAccountManager _accountManager;
    private readonly SystemPassword _systemPassword;

    public AdminAccountService(
        IAdminAccountRepository adminAccountRepository,
        CurrentAccountManager accountManager,
        SystemPassword systemPassword)
    {
        _adminAccountRepository = adminAccountRepository;
        _accountManager = accountManager;
        _systemPassword = systemPassword;
    }

    public LoginResult Login(string systemPassword)
    {
        if (_systemPassword.Password != systemPassword)
        {
            Environment.Exit(0);
        }

        _accountManager.Roles = Roles.Admin;
        return new LoginResult.Success();
    }

    public CommandResult CreateAccount(long id, int pin, decimal value)
    {
        _adminAccountRepository.CreateAccount(id, pin, value);
        return new CommandResult.Success<string>($"New account with id:{id}");
    }

    public void LogOut()
    {
        _accountManager.Roles = null;
    }
}