using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Commands;

namespace Lab5.Application.Abstraction.Repositories;

public interface IUserAccountRepository
{
    public Account? FindAccountById(long id);
    public decimal ShowBalance(long id);
    public void OperationWithMoney(long id, decimal value);
    public IEnumerable<Command> ShowTransactionHistory(long id);
}