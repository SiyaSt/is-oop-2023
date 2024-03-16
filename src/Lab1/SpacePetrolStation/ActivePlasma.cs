namespace Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;

public class ActivePlasma : IFuel
{
   public ActivePlasma(double amount)
   {
      FuelAmount = amount;
   }

   public double FuelAmount { get; }
}