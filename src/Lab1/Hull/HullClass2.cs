using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hull;

public record HullClass2 : IHull
{
    public double HullStrength { get; private set; } = 5;
    public Results AttackHull(double obstacleDamage)
    {
        const double damageGradation = 1.5;
        HullStrength -= obstacleDamage / damageGradation;
        if (HullStrength < 0)
        {
            return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}