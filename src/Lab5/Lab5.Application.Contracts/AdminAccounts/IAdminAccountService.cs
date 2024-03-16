using Lab5.Application.Contracts.Results;

namespace Lab5.Application.Contracts.AdminAccounts;

public interface IAdminAccountService
{
    public LoginResult Login(string systemPassword);
    public CommandResult CreateAccount(long id, int pin, decimal value);
    public void LogOut();
}