namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessorBuilder
{
    IProcessorBuilder WithCoreFrequency(int frequency);
    IProcessorBuilder WithCoreAmount(int amount);
    IProcessorBuilder WithProcessorSocket(string socket);
    IProcessorBuilder WithBuiltInVideoCore(BuiltInVideoCore? builtInVideoCore);
    IProcessorBuilder AddMemoryFrequencies(int frequency);
    IProcessorBuilder WithTdp(int tdp);
    IProcessorBuilder WithPowerConsumption(int power);
    IProcessor Builder();
}