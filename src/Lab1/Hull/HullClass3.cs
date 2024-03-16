using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hull;

public record HullClass3 : IHull
{
    public double HullStrength { get; private set; } = 20;
    public Results AttackHull(double obstacleDamage)
    {
        const double damageGradation = 2;
        HullStrength -= obstacleDamage / damageGradation;
        if (HullStrength < 0)
        {
            return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}