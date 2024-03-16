using Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;
using Itmo.ObjectOrientedProgramming.Lab1.Time;

namespace Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

public class AlphaJumpEngine : IJumpEngine
{
    public double EngineSpeed { get; private set; } = 130;

    public Results.SpaceShipRouteResult RouteResult(double distance)
    {
        const int fuelConsumptionPerKm = 3;
        const double decelerationRate = 0.1;
        double fuel = fuelConsumptionPerKm + (distance * fuelConsumptionPerKm);
        var gravitationalMatter = new GravitationalMatter(fuel);
        double timeAmount = EngineSpeed / distance;
        var time = new Time.Time(timeAmount);
        EngineSpeed -= distance * decelerationRate;
        if (EngineSpeed < 0)
        {
            return new Results.SpaceShipRouteResult.ShipLossSpaceShipRouteResult();
        }

        return new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(new IFuel[] { gravitationalMatter }, new ITime[] { time });
    }
}