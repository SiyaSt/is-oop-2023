using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.HDD;

public interface IHdd : IComponent, IHddDirect
{
    public int PowerConsumption { get; }
}