using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

public interface IJumpEngine
{
    public Results.SpaceShipRouteResult RouteResult(double distance);
}