namespace Itmo.ObjectOrientedProgramming.Lab2.SSD;

public class Ssd : ISsd
{
    internal Ssd(string? pciE, string? sata, int memoryCapacity, int maxSpeed, int powerConsumption)
    {
        PciE = pciE;
        Sata = sata;
        MemoryCapacity = memoryCapacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? PciE { get; }
    public string? Sata { get; }
    public int MemoryCapacity { get; }
    public int MaxSpeed { get; }
    public int PowerConsumption { get; }
    public ISsdBuilder Direct(ISsdBuilder ssdBuilder)
    {
        ssdBuilder.WithPciE(PciE);
        ssdBuilder.WithSata(Sata);
        ssdBuilder.WithMemoryCapacity(MemoryCapacity);
        ssdBuilder.WithMaxSpeed(MaxSpeed);
        ssdBuilder.WithPowerConsumption(PowerConsumption);
        return ssdBuilder;
    }
}