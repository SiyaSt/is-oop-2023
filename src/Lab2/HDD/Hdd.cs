namespace Itmo.ObjectOrientedProgramming.Lab2.HDD;

public class Hdd : IHdd
{
    internal Hdd(string sata, int memoryCapacity, int spindleSpeed, int powerConsumption)
    {
        Sata = sata;
        MemoryCapacity = memoryCapacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Sata { get; }
    public int MemoryCapacity { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }
    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        hddBuilder.WithSata(Sata);
        hddBuilder.WithMemoryCapacity(MemoryCapacity);
        hddBuilder.WithSpindleSpeed(SpindleSpeed);
        hddBuilder.WithPowerConsumption(PowerConsumption);
        return hddBuilder;
    }
}