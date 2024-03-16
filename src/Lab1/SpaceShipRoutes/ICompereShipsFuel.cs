using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRoutes;

public interface ICompereShipsFuel
{
    public ISpaceShip? TwoShipsCompereCreditsSpent(ISpaceShip ship1, ISpaceShip ship2);
}