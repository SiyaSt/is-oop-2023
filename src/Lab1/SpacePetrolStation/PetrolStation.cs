using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;

public class PetrolStation : IPetrolStation
{
    public decimal ConvertingFuelIntoMoney(IList<IFuel> fuel)
    {
        decimal credits = 0;
        foreach (IFuel collection in fuel)
        {
            switch (collection)
            {
                case GravitationalMatter gravitationalMatter:
                {
                    const int moneyPerKm = 3;
                    credits += (decimal)(gravitationalMatter.FuelAmount * moneyPerKm);
                    break;
                }

                case ActivePlasma activePlasma:
                {
                    const int moneyPerKm = 2;
                    credits += (decimal)(activePlasma.FuelAmount * moneyPerKm);
                    break;
                }
            }
        }

        return credits;
    }
}