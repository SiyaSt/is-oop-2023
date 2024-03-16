using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.HDD;

public class HddBuilder : IHddBuilder
{
    private string? _sata;
    private int _memoryCapacity;
    private int _spindleSpeed;
    private int _powerConsumption;
    public IHddBuilder WithSata(string sata)
    {
        _sata = sata;
        return this;
    }

    public IHddBuilder WithMemoryCapacity(int capacity)
    {
        _memoryCapacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(int speed)
    {
        _spindleSpeed = speed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int power)
    {
        _powerConsumption = power;
        return this;
    }

    public IHdd Builder()
    {
        return new Hdd(
            _sata ?? throw new ArgumentNullException(nameof(_sata)),
            _memoryCapacity,
            _spindleSpeed,
            _powerConsumption);
    }
}