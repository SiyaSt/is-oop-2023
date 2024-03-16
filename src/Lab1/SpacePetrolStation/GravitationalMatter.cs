namespace Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;

public class GravitationalMatter : IFuel
{
    public GravitationalMatter(double amount)
    {
        FuelAmount = amount;
    }

    public double FuelAmount { get; }
}