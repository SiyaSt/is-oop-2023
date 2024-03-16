using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.SSD;

public interface ISsd : IComponent, ISsdDirect
{
    public int PowerConsumption { get; }
}