using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(double version);
    IBiosBuilder AddCpuCollection(IProcessor processor);
    IBios Build();
}