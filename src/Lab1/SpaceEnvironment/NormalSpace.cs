using Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceEnvironment;

public class NormalSpace : ISpaceEnvironment
{
    private readonly INormalSpaceObstacles _obstacles;
    private readonly int _obstacleAmount;
    private readonly double _distance;

    public NormalSpace(INormalSpaceObstacles obstacles, int obstacleAmount, int distance)
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

        const double environmentDensity = 1;
        return ship.Engine.RouteResult(_distance, environmentDensity);
    }
}