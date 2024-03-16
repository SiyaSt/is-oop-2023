using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hull;

public record HullClass1 : IHull
{
    public double HullStrength { get; private set; } = 1;
    public Results AttackHull(double obstacleDamage)
    {
        HullStrength -= obstacleDamage;
        if (HullStrength < 0)
        {
            return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}