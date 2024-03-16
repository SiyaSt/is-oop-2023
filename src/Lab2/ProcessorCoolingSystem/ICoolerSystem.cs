using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public interface ICoolerSystem : IComponent, ICoolerSystemDirect
{
    public Dimension? Dimension { get; }
    public string? Socket { get; }
    public int Tdp { get; }
}