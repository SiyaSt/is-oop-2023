using Lab5.Application.Contracts.Results;

namespace Lab5.Application.Contracts.UserAccounts;

public interface IUserAccountService
{
    public LoginResult Login(long id, int pinCode);
    public CommandResult ShowBalance();
    public CommandResult WithdrawMoney(decimal value);
    public CommandResult AddMoney(decimal value);
    public CommandResult ShowTransactionHistory();
    public void LogOut();
}