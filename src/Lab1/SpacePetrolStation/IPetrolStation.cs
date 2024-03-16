using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;

public interface IPetrolStation
{
    public decimal ConvertingFuelIntoMoney(IList<IFuel> fuel);
}