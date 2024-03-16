namespace Lab5.Application.Models.Accounts;

public record Account(long Id, int Pin, decimal Balance)
{
    public decimal Balance { get; set; } = Balance;
}