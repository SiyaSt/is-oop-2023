using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.DOCP;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.DDR;

public class DdrBuilder : IDdrBuilder
{
    private readonly List<IXmp?> _xmps;
    private readonly List<IDocp?> _docps;
    private int _memorySize;
    private int _voltage;
    private int _frequency;
    private string? _formFactor;
    private string? _version;
    private int _powerConsumption;

    public DdrBuilder()
    {
        _xmps = new List<IXmp?>();
        _docps = new List<IDocp?>();
    }

    public IDdrBuilder WithAvailableMemorySize(int size)
    {
        _memorySize = size;
        return this;
    }

    public IDdrBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IDdrBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IDdrBuilder AddXmp(IXmp? xmp)
    {
        _xmps.Add(xmp);
        return this;
    }

    public IDdrBuilder AddDocp(IDocp? docp)
    {
        _docps.Add(docp);
        return this;
    }

    public IDdrBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IDdrBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IDdrBuilder WithPowerConsumption(int power)
    {
        _powerConsumption = power;
        return this;
    }

    public IDdr Build()
    {
        return new Ddr(
            _memorySize,
            _voltage,
            _frequency,
            (IReadOnlyCollection<IXmp>?)_xmps,
            (IReadOnlyCollection<IDocp>?)_docps,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _powerConsumption);
    }
}