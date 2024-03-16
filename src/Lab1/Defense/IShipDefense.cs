using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Defense;

public interface IShipDefense
{
    public IDeflector? Deflector { get; }
    public Results? AttackShip(double damageCoefficient);
}