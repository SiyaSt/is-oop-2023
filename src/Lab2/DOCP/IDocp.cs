using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.DOCP;

public interface IDocp : IComponent
{
    public string? Timing { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}