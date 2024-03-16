using Itmo.ObjectOrientedProgramming.Lab1.Defense;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;

public class PleasureShuttle : ISpaceShip
{
    public PleasureShuttle()
    {
        IDeflector? deflector = null;
        IHull hull = new HullClass1();
        Engine = new ClassCPulseEngine();
        JumpEngine = null;
        ShipDefense = new ShipDefense(deflector, hull);
        AntiNitriteRadiator = null;
    }

    public IShipDefense ShipDefense { get; }
    public IPulseEngine Engine { get; }
    public IJumpEngine? JumpEngine { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; }
}