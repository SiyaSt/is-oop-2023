using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Contracts.Results;
using Lab5.Application.CurrentAccounts;
using Lab5.Application.Models.Accounts;
using Lab5.Application.UserAccounts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class BankApplicationTests
{
    [Fact]
    public void WithdrawMoneyFromAccount_ShouldBeProperBalance_WhenEnoughMoneyOnBalance()
    {
        // Arrange
        IUserAccountRepository accountRepository = Substitute.For<IUserAccountRepository>();
        ICommandRepository commandRepository = Substitute.For<ICommandRepository>();
        var currentUserAccountService = new CurrentUserAccountManager();
        currentUserAccountService.Account = new Account(123, 123, 186);
        var currentService = new CurrentAccountManager();
        currentService.Roles = Roles.User;
        var userAccountService = new UserAccountService(
            accountRepository,
            currentUserAccountService,
            commandRepository,
            currentService);

        // Act
        CommandResult result = userAccountService.WithdrawMoney(80);

        // Assert
        Assert.IsType<CommandResult.Success<string>>(result);
    }

    [Fact]
    public void WithdrawMoneyFromAccount_ShouldBeReturnError_WhenNotEnoughMoneyOnBalance()
    {
        // Arrange
        IUserAccountRepository accountRepository = Substitute.For<IUserAccountRepository>();
        ICommandRepository commandRepository = Substitute.For<ICommandRepository>();
        var currentUserAccountService = new CurrentUserAccountManager();
        currentUserAccountService.Account = new Account(123, 123, 186);
        var currentService = new CurrentAccountManager();
        currentService.Roles = Roles.User;
        var userAccountService = new UserAccountService(
            accountRepository,
            currentUserAccountService,
            commandRepository,
            currentService);

        // Act
        CommandResult result = userAccountService.WithdrawMoney(200);

        // Assert
        Assert.IsType<CommandResult.ErrorExecution>(result);
    }

    [Fact]
    public void AddMoneyToAccount_ShouldBeProperBalance_WhenEverythingGood()
    {
        // Arrange
        IUserAccountRepository accountRepository = Substitute.For<IUserAccountRepository>();
        ICommandRepository commandRepository = Substitute.For<ICommandRepository>();
        var currentUserAccountService = new CurrentUserAccountManager();
        currentUserAccountService.Account = new Account(123, 123, 186);
        var currentService = new CurrentAccountManager();
        currentService.Roles = Roles.User;
        var userAccountService = new UserAccountService(
            accountRepository,
            currentUserAccountService,
            commandRepository,
            currentService);

        // Act
        CommandResult result = userAccountService.AddMoney(200);

        // Assert
        Assert.IsType<CommandResult.Success<string>>(result);
    }
}