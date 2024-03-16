using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.XMP;

public class XmpBuilder : IXmpBuilder
{
    private string? _timing;
    private int _voltage;
    private int _frequency;
    public IXmpBuilder AddTiming(string timing)
    {
        _timing = timing;
        return this;
    }

    public IXmpBuilder AddVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpBuilder AddFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IXmp Builder()
    {
        return new Xmp(_timing ?? throw new ArgumentNullException(nameof(_timing)), _voltage, _frequency);
    }
}