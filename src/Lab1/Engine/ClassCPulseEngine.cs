using Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;
using Itmo.ObjectOrientedProgramming.Lab1.Time;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class ClassCPulseEngine : IPulseEngine
{
    public double EngineSpeed { get; private set; } = 100;

    public Results.SpaceShipRouteResult RouteResult(double distance, double density)
    {
        const int fuelConsumptionPerKm = 5;
        const double decelerationRate = 0.1;
        double fuel = fuelConsumptionPerKm + (distance / fuelConsumptionPerKm * density);
        var activePlasma = new ActivePlasma(fuel);
        double timeAmount = EngineSpeed / distance;
        var time = new Time.Time(timeAmount);
        EngineSpeed -= distance * decelerationRate;
        if (EngineSpeed < 0)
        {
            return new Results.SpaceShipRouteResult.ShipLossSpaceShipRouteResult();
        }

        return new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(new IFuel[] { activePlasma }, new ITime[] { time });
    }
}