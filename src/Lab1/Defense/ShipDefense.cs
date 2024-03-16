using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Defense;

public class ShipDefense : IShipDefense
{
    public ShipDefense(IDeflector? deflector, IHull hull)
    {
        Deflector = deflector;
        Hull = hull;
    }

    public IDeflector? Deflector { get; }
    public IHull Hull { get; }
    public Results? AttackShip(double damageCoefficient)
    {
        Results? result = null;
        if (Deflector is not null)
        {
            result = Deflector.AttackDeflector(damageCoefficient);
        }

        if (result is Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult || Deflector is null)
        {
            result = Hull.AttackHull(damageCoefficient);
        }

        return result;
    }
}