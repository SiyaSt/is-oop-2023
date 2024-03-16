using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessor : IComponent, IProcessorDirect
{
    public string? ProcessorSocket { get; }
    public BuiltInVideoCore? BuiltInVideoCore { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }
}