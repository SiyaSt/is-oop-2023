using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;
using Itmo.ObjectOrientedProgramming.Lab1.Time;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

public record Results
{
    public record ObstaclesResults : Results
    {
        public record CrewLossSpaceShipRouteResult : ObstaclesResults;

        public record ShipDestructionSpaceShipRouteResult : ObstaclesResults;

        public record SuccessSpaceShipAttackResult : ObstaclesResults;
    }

    public record SpaceShipRouteResult : Results
    {
        public record ShipLossSpaceShipRouteResult : SpaceShipRouteResult;
        public record SuccessSpaceShipRouteResult(IList<IFuel> Fuel, IList<ITime> Time) : SpaceShipRouteResult;
    }
}