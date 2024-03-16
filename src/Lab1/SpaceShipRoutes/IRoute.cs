using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRoutes;

public interface IRoute
{
    public Results ShipJourney(ISpaceShip ship);
}
