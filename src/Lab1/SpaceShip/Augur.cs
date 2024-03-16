using Itmo.ObjectOrientedProgramming.Lab1.Defense;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;

public class Augur : ISpaceShip
{
    public Augur(bool photonDeflectorPresence)
    {
        IDeflector deflector = new DeflectorClass3();
        if (photonDeflectorPresence)
        {
            deflector = new PhotonicsDeflector(deflector);
        }

        IHull hull = new HullClass3();
        ShipDefense = new ShipDefense(deflector, hull);
        Engine = new ClassEPulseEngine();
        JumpEngine = new AlphaJumpEngine();
        AntiNitriteRadiator = null;
    }

    public IShipDefense ShipDefense { get; }
    public IPulseEngine Engine { get; }
    public IJumpEngine? JumpEngine { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; }
}