using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceEnvironment;

public interface ISpaceEnvironment
{
    public Results ShipInSpace(ISpaceShip ship);
}