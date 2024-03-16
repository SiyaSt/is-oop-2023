using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;

public class SpaceWhale : INitriteNebulaSpaceObstacles
{
    private const double DamageCoefficient = 38.99;

    public Results? AttackShip(int amount, ISpaceShip spaceShip)
    {
        Results? result = new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
        if (spaceShip.AntiNitriteRadiator is not null)
        {
            return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
        }

        for (int i = 0; i < amount & result is Results.ObstaclesResults.SuccessSpaceShipAttackResult; i++)
        {
            result = spaceShip.ShipDefense.AttackShip(DamageCoefficient);
        }

        return result;
    }
}