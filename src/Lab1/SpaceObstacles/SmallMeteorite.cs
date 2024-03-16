using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;

public class SmallMeteorite : INormalSpaceObstacles
{
    private const double DamageCoefficient = 0.99;

    public Results? AttackShip(int amount, ISpaceShip spaceShip)
    {
        Results? result = new Results.ObstaclesResults.SuccessSpaceShipAttackResult();

        for (int i = 0; i < amount & result is Results.ObstaclesResults.SuccessSpaceShipAttackResult; i++)
        {
           result = spaceShip.ShipDefense.AttackShip(DamageCoefficient);
        }

        return result;
    }
}