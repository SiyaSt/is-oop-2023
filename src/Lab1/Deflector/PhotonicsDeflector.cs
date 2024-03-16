using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class PhotonicsDeflector : IPhotonicsDeflector
{
    public PhotonicsDeflector(IDeflector? deflector)
    {
        if (deflector is not null)
        {
            Deflector = deflector;
        }
    }

    public IDeflector? Deflector { get; private set; }
    public int PhotonicsStrength { get; private set; } = 3;
    public Results AttackDeflector(double obstacleDamage)
    {
        if (Deflector != null)
        {
            return Deflector.AttackDeflector(obstacleDamage);
        }

        return new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult();
    }

    public Results? AttackPhotonicsDeflector(int obstacleAmount)
    {
        PhotonicsStrength -= obstacleAmount;
        if (PhotonicsStrength < 0)
        {
            return new Results.ObstaclesResults.CrewLossSpaceShipRouteResult();
        }

        return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
    }
}