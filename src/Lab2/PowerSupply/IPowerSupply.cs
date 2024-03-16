using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupply : IComponent, IPowerSupplyDirect
{
    public int PeakLoad { get; }
}