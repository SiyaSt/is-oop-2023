using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class DeflectorClass3 : IDeflector
{
    public double DeflectorStrength { get; private set; } = 40;
    public Results AttackDeflector(double obstacleDamage)
    {
        const double damageGradation = 2;
        DeflectorStrength -= obstacleDamage / damageGradation;
        if (DeflectorStrength < 0)
        {
            return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}