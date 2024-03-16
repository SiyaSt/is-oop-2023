using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;

public class AntimatterFlare : INebulaSpaceObstacles
{
    public Results? AttackShip(int amount, ISpaceShip spaceShip)
    {
        if (amount == 0)
        {
            return new Results.ObstaclesResults.SuccessSpaceShipAttackResult();
        }

        return spaceShip.ShipDefense.Deflector is not IPhotonicsDeflector photonicsDeflector
            ? new Results.ObstaclesResults.CrewLossSpaceShipRouteResult()
            : photonicsDeflector.AttackPhotonicsDeflector(amount);
    }
}