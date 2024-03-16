using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;
using Itmo.ObjectOrientedProgramming.Lab1.Time;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRoutes;

public class Route : IRoute
{
    private readonly IList<ISpaceEnvironment> _spaceEnvironments;

    public Route(IList<ISpaceEnvironment> spaceEnvironments)
    {
        _spaceEnvironments = spaceEnvironments;
        PetrolStation = new PetrolStation();
    }

    public PetrolStation PetrolStation { get; }
    public Results ShipJourney(ISpaceShip ship)
    {
        IList<IFuel> interimFuel = new List<IFuel>();
        IList<ITime> interimTime = new List<ITime>();
        foreach (ISpaceEnvironment spaceEnvironment in _spaceEnvironments)
        {
            Results result = spaceEnvironment.ShipInSpace(ship);
            if (result is not Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult or Results.ObstaclesResults.SuccessSpaceShipAttackResult)
            {
                return result;
            }

            if (result is Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult successSpaceShipRouteResult)
            {
                foreach (IFuel fuel in successSpaceShipRouteResult.Fuel) interimFuel.Add(fuel);
                foreach (ITime time in successSpaceShipRouteResult.Time) interimTime.Add(time);
            }
        }

        var glResult = new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(interimFuel, interimTime);
        return glResult;
    }
}