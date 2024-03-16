namespace Lab5.Application.Contracts.UserAccounts;

public interface ICurrentUserAccountService
{
    public Models.Accounts.Account? Account { get; set; }
}