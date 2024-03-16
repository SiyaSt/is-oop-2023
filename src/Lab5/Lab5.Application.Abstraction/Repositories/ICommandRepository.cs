namespace Lab5.Application.Abstraction.Repositories;

public interface ICommandRepository
{
    public void AddWithdrawOperationToHistory(long id, decimal value);
    public void AddAddOperationToHistory(long id, decimal value);
}