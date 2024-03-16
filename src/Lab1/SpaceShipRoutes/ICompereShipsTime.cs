using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRoutes;

public interface ICompereShipsTime
{
    public ISpaceShip? TwoShipsCompereTimeSpent(ISpaceShip ship1, ISpaceShip ship2);
}