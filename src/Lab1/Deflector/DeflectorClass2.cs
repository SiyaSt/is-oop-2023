using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class DeflectorClass2 : IDeflector
{
    public double DeflectorStrength { get; private set; } = 10;
    public Results AttackDeflector(double obstacleDamage)
    {
        const double damageGradation = 1.5;
        DeflectorStrength -= obstacleDamage / damageGradation;
        if (DeflectorStrength < 0)
        {
            return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}