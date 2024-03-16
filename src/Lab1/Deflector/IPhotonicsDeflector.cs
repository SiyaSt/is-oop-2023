using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public interface IPhotonicsDeflector : IDeflector
{
    public Results? AttackPhotonicsDeflector(int obstacleAmount);
}