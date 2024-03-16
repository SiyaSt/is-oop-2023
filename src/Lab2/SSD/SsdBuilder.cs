namespace Itmo.ObjectOrientedProgramming.Lab2.SSD;

public class SsdBuilder : ISsdBuilder
{
    private string? _pciE;
    private string? _sata;
    private int _memoryCapacity;
    private int _maxSpeed;
    private int _powerConsumption;
    public ISsdBuilder WithPciE(string? pciE)
    {
        _pciE = pciE;
        return this;
    }

    public ISsdBuilder WithSata(string? sata)
    {
        _sata = sata;
        return this;
    }

    public ISsdBuilder WithMemoryCapacity(int memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
        return this;
    }

    public ISsdBuilder WithMaxSpeed(int speed)
    {
        _maxSpeed = speed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int power)
    {
        _powerConsumption = power;
        return this;
    }

    public ISsd Builder()
    {
        return new Ssd(_pciE, _sata, _memoryCapacity, _maxSpeed, _powerConsumption);
    }
}