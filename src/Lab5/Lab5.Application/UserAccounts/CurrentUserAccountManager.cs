using Lab5.Application.Contracts.UserAccounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.UserAccounts;

public class CurrentUserAccountManager : ICurrentUserAccountService
{
    public Account? Account { get; set; }
}