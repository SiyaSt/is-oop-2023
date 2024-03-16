using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;

public interface IObstacles
{
    public Results? AttackShip(int amount, ISpaceShip spaceShip);
}