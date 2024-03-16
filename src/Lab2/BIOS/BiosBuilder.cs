using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public class BiosBuilder : IBiosBuilder
{
    private readonly List<IProcessor> _processors;
    private string? _type;
    private double _version;

    public BiosBuilder()
    {
        _processors = new List<IProcessor>();
    }

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(double version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder AddCpuCollection(IProcessor processor)
    {
        _processors.Add(processor);
        return this;
    }

    public IBios Build()
    {
        return new Bios(_type ?? throw new ArgumentNullException(nameof(_type)), _version, _processors);
    }
}