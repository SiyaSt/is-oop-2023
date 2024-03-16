using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public interface IBios : IComponent, IBiosDirect
{
    public IReadOnlyCollection<IProcessor> Cpu { get; }
}