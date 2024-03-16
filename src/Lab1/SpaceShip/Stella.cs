using Itmo.ObjectOrientedProgramming.Lab1.Defense;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;

public class Stella : ISpaceShip
{
    public Stella(bool photonDeflectorPresence)
    {
        IDeflector deflector = new DeflectorClass1();
        if (photonDeflectorPresence)
        {
            deflector = new PhotonicsDeflector(deflector);
        }

        IHull hull = new HullClass1();
        Engine = new ClassCPulseEngine();
        ShipDefense = new ShipDefense(deflector, hull);
        JumpEngine = new OmegaJumpEngine();
        AntiNitriteRadiator = null;
    }

    public IShipDefense ShipDefense { get; }
    public IPulseEngine Engine { get; }
    public IJumpEngine? JumpEngine { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; }
}