namespace Itmo.ObjectOrientedProgramming.Lab2.SSD;

public interface ISsdBuilder
{
    ISsdBuilder WithPciE(string? pciE);
    ISsdBuilder WithSata(string? sata);
    ISsdBuilder WithMemoryCapacity(int memoryCapacity);
    ISsdBuilder WithMaxSpeed(int speed);
    ISsdBuilder WithPowerConsumption(int power);
    ISsd Builder();
}