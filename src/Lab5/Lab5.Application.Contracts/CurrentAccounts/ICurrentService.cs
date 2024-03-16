using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.CurrentAccounts;

public interface ICurrentService
{
    public Roles? Roles { get; set; }
}