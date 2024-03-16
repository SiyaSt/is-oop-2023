using Itmo.ObjectOrientedProgramming.Lab1.Defense;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;

public class Meredian : ISpaceShip
{
    public Meredian(bool photonDeflectorPresence)
    {
        IDeflector deflector = new DeflectorClass2();
        if (photonDeflectorPresence)
        {
            deflector = new PhotonicsDeflector(deflector);
        }

        IHull hull = new HullClass2();
        Engine = new ClassEPulseEngine();
        JumpEngine = null;
        ShipDefense = new ShipDefense(deflector, hull);
        AntiNitriteRadiator = new AntiNitriteRadiator();
    }

    public IShipDefense ShipDefense { get; }
    public IPulseEngine Engine { get; }
    public IJumpEngine? JumpEngine { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; }
}