using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class DeflectorClass1 : IDeflector
{
    public double DeflectorStrength { get; private set; } = 3;
    public Results AttackDeflector(double obstacleDamage)
    {
        DeflectorStrength -= obstacleDamage;
        if (DeflectorStrength < 0)
        {
            return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}