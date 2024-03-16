using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.DOCP;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.DDR;

public interface IDdr : IComponent, IDdrDirect
{
    public int AvailableMemorySize { get; }
    public int Voltage { get; }
    public int Frequency { get; }
    public IReadOnlyCollection<IXmp>? Xmp { get; }
    public IReadOnlyCollection<IDocp>? Docp { get; }
    public string? FormFactor { get; }
    public string? Version { get; }
    public int PowerConsumption { get; }
}