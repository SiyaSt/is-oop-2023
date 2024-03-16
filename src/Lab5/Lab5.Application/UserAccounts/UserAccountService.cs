using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.UserAccounts;
using Lab5.Application.CurrentAccounts;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Commands;

namespace Lab5.Application.UserAccounts;

public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository _accountRepository;
    private readonly CurrentUserAccountManager _userAccountManager;
    private readonly CurrentAccountManager _accountManager;
    private readonly ICommandRepository _commandRepository;

    public UserAccountService(
        IUserAccountRepository accountRepository,
        CurrentUserAccountManager userAccountManager,
        ICommandRepository commandRepository,
        CurrentAccountManager accountManager)
    {
        _accountRepository = accountRepository;
        _userAccountManager = userAccountManager;
        _commandRepository = commandRepository;
        _accountManager = accountManager;
    }

    public LoginResult Login(long id, int pinCode)
    {
        Account? account = _accountRepository.FindAccountById(id);

        if (account is null)
        {
            return new LoginResult.NotFound();
        }

        if (account.Pin != pinCode)
        {
            return new LoginResult.ErrorPin();
        }

        _accountManager.Roles = Roles.User;

        _userAccountManager.Account = account;
        return new LoginResult.Success();
    }

    public CommandResult ShowBalance()
    {
        if (_userAccountManager.Account is null)
        {
            return new CommandResult.ErrorExecution("Not login in account");
        }

        decimal balance = _accountRepository.ShowBalance(_userAccountManager.Account.Id);

        return new CommandResult.Success<decimal>(balance);
    }

    public CommandResult WithdrawMoney(decimal value)
    {
        if (_userAccountManager.Account is null)
        {
            return new CommandResult.ErrorExecution("Not login in account");
        }

        _userAccountManager.Account.Balance -= value;
        if (_userAccountManager.Account.Balance < 0)
        {
            return new CommandResult.ErrorExecution("Not enough money on balance");
        }

        _accountRepository.OperationWithMoney(_userAccountManager.Account.Id, _userAccountManager.Account.Balance);
        _commandRepository.AddWithdrawOperationToHistory(_userAccountManager.Account.Id, value);
        return new CommandResult.Success<string>("Successful execution");
    }

    public CommandResult AddMoney(decimal value)
    {
        if (_userAccountManager.Account is null)
        {
            return new CommandResult.ErrorExecution("Not login in account");
        }

        _userAccountManager.Account.Balance += value;

        _accountRepository.OperationWithMoney(_userAccountManager.Account.Id, _userAccountManager.Account.Balance);
        _commandRepository.AddAddOperationToHistory(_userAccountManager.Account.Id, value);
        return new CommandResult.Success<string>("Successful execution");
    }

    public CommandResult ShowTransactionHistory()
    {
        if (_userAccountManager.Account is null)
        {
            return new CommandResult.ErrorExecution("Not login in account");
        }

        IEnumerable<Command> history = _accountRepository.ShowTransactionHistory(_userAccountManager.Account.Id);
        return new CommandResult.Success<IEnumerable<Command>>(history);
    }

    public void LogOut()
    {
        _userAccountManager.Account = null;
        _accountManager.Roles = null;
    }
}