using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.DOCP;

public class DocpBuilder : IDocpBuilder
{
    private string? _timing;
    private int _voltage;
    private int _frequency;
    public IDocpBuilder WithTiming(string timing)
    {
        _timing = timing;
        return this;
    }

    public IDocpBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IDocpBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IDocp Builder()
    {
        return new Docp(_timing ?? throw new ArgumentNullException(nameof(_timing)), _voltage, _frequency);
    }
}