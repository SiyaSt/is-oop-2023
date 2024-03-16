using Lab5.Application.Contracts.CurrentAccounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.CurrentAccounts;

public class CurrentAccountManager : ICurrentService
{
    public Roles? Roles { get; set; }
}