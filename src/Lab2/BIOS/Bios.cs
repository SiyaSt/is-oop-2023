using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public class Bios : IBios
{
    internal Bios(string type, double version, IReadOnlyCollection<IProcessor> cpu)
    {
        Type = type;
        Version = version;
        Cpu = cpu;
    }

    public string Type { get; }
    public double Version { get; }
    public IReadOnlyCollection<IProcessor> Cpu { get; }
    public IBiosBuilder Direct(IBiosBuilder biosBuilder)
    {
        biosBuilder.WithType(Type);
        biosBuilder.WithVersion(Version);
        foreach (IProcessor processor in Cpu)
        {
            biosBuilder.AddCpuCollection(processor);
        }

        return biosBuilder;
    }
}