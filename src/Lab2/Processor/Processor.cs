using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class Processor : IProcessor
{
    public Processor(int coreFrequency, int coreAmount, string processorSocket, BuiltInVideoCore? builtInVideoCore, IReadOnlyCollection<int> memoryFrequencies, int tdp, int powerConsumption)
    {
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        ProcessorSocket = processorSocket;
        BuiltInVideoCore = builtInVideoCore;
        MemoryFrequencies = memoryFrequencies;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public int CoreFrequency { get; }
    public int CoreAmount { get; }
    public string ProcessorSocket { get; }
    public BuiltInVideoCore? BuiltInVideoCore { get; }
    public IReadOnlyCollection<int> MemoryFrequencies { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }
    public IProcessorBuilder Direct(IProcessorBuilder processorBuilder)
    {
        processorBuilder.WithCoreFrequency(CoreFrequency);
        processorBuilder.WithCoreAmount(CoreAmount);
        processorBuilder.WithProcessorSocket(ProcessorSocket);
        processorBuilder.WithBuiltInVideoCore(BuiltInVideoCore);
        foreach (int memoryFrequency in MemoryFrequencies)
        {
            processorBuilder.AddMemoryFrequencies(memoryFrequency);
        }

        processorBuilder.WithTdp(Tdp);
        processorBuilder.WithPowerConsumption(PowerConsumption);
        return processorBuilder;
    }
}