using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class ProcessorBuilder : IProcessorBuilder
{
    private readonly List<int> _memoryFrequency;
    private int _coreFrequency;
    private int _coreAmount;
    private string? _socket;
    private BuiltInVideoCore? _builtInVideoCore;
    private int _tdp;
    private int _powerConsumption;

    public ProcessorBuilder()
    {
        _memoryFrequency = new List<int>();
    }

    public IProcessorBuilder WithCoreFrequency(int frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public IProcessorBuilder WithCoreAmount(int amount)
    {
        _coreAmount = amount;
        return this;
    }

    public IProcessorBuilder WithProcessorSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IProcessorBuilder WithBuiltInVideoCore(BuiltInVideoCore? builtInVideoCore)
    {
        _builtInVideoCore = builtInVideoCore;
        return this;
    }

    public IProcessorBuilder AddMemoryFrequencies(int frequency)
    {
        _memoryFrequency.Add(frequency);
        return this;
    }

    public IProcessorBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorBuilder WithPowerConsumption(int power)
    {
        _powerConsumption = power;
        return this;
    }

    public IProcessor Builder()
    {
        return new Processor(
            _coreFrequency,
            _coreAmount,
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _builtInVideoCore,
            _memoryFrequency,
            _tdp,
            _powerConsumption);
    }
}