using Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceEnvironment;

public class NebulaSpace : ISpaceEnvironment
{
    private readonly INebulaSpaceObstacles _obstacles;
    private readonly int _obstacleAmount;
    private readonly double _distance;

    public NebulaSpace(INebulaSpaceObstacles obstacles, int obstacleAmount, int distance)
    {
        _obstacles = obstacles;
        _obstacleAmount = obstacleAmount;
        _distance = distance;
    }

    public Results ShipInSpace(ISpaceShip ship)
    {
        Results? result = _obstacles.AttackShip(_obstacleAmount, ship);
        if (result is Results.ObstaclesResults.CrewLossSpaceShipRouteResult or
            Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult)
        {
            return result;
        }

        return ship.JumpEngine == null
                    ? new Results.SpaceShipRouteResult.ShipLossSpaceShipRouteResult()
                    : ship.JumpEngine.RouteResult(_distance) as Results;
    }
}