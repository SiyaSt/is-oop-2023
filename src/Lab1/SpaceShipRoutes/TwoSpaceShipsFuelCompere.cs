using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRoutes;

public class TwoSpaceShipsFuelCompere : ICompereShipsFuel, ICompereShipsTime
{
    private readonly Route _route1;
    private readonly Route _route2;

    public TwoSpaceShipsFuelCompere(IList<ISpaceEnvironment> spaceEnvironments)
    {
        _route1 = new Route(spaceEnvironments);
        _route2 = new Route(spaceEnvironments);
    }

    public ISpaceShip? TwoShipsCompereCreditsSpent(ISpaceShip ship1, ISpaceShip ship2)
    {
        ISpaceShip? result = null;
        Results journeyResult1 = _route1.ShipJourney(ship1);
        Results journeyResult2 = _route2.ShipJourney(ship2);
        if (journeyResult1 is Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult successSpaceShipRouteResult1 &&
            journeyResult2 is Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult successSpaceShipRouteResult2)
        {
            result = _route1.PetrolStation.ConvertingFuelIntoMoney(successSpaceShipRouteResult1.Fuel) >
                     _route2.PetrolStation.ConvertingFuelIntoMoney(successSpaceShipRouteResult2.Fuel)
                ? ship2
                : ship1;
        }
        else if (journeyResult1 is not Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult)
        {
            result = ship2;
        }
        else if (journeyResult2 is not Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult)
        {
            result = ship1;
        }

        return result;
    }

    public ISpaceShip? TwoShipsCompereTimeSpent(ISpaceShip ship1, ISpaceShip ship2)
    {
        ISpaceShip? result = null;
        Results journeyResult1 = _route1.ShipJourney(ship1);
        Results journeyResult2 = _route2.ShipJourney(ship2);
        if (journeyResult1 is Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult successSpaceShipRouteResult1 &&
            journeyResult2 is Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult successSpaceShipRouteResult2)
        {
            result = successSpaceShipRouteResult1.Time.Sum(x => x.TimeAmount) >
                    successSpaceShipRouteResult2.Time.Sum(x => x.TimeAmount)
                ? ship2
                : ship1;
        }
        else if (journeyResult1 is not Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult)
        {
            result = ship2;
        }
        else if (journeyResult2 is not Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult)
        {
            result = ship1;
        }

        return result;
    }
}