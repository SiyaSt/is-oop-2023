using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;
using Itmo.ObjectOrientedProgramming.Lab1.Time;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class ClassEPulseEngine : IPulseEngine
{
    public double EngineSpeed { get; private set; } = 10;

    public Results.SpaceShipRouteResult RouteResult(double distance, double density)
    {
        double fuelConsumptionPerKm = Math.Exp(2);
        const double decelerationRate = 0.2;
        double fuel = fuelConsumptionPerKm + (distance / fuelConsumptionPerKm * density);
        double exp = Math.Exp(EngineSpeed);
        var activePlasma = new ActivePlasma(fuel);
        double timeAmount = EngineSpeed / distance;
        var time = new Time.Time(timeAmount);
        EngineSpeed = exp - (distance * decelerationRate);
        if (EngineSpeed < 0)
        {
            return new Results.SpaceShipRouteResult.ShipLossSpaceShipRouteResult();
        }

        return new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(new IFuel[] { activePlasma }, new ITime[] { time });
    }
}