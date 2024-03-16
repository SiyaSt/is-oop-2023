using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public interface IPulseEngine
{
    public Results.SpaceShipRouteResult RouteResult(double distance, double density);
}