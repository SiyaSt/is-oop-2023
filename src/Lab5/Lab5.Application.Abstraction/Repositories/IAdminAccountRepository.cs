namespace Lab5.Application.Abstraction.Repositories;

public interface IAdminAccountRepository
{
    public void CreateAccount(long id, int pin, decimal value);
}