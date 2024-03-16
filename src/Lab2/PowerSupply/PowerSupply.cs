namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupply : IPowerSupply
{
    internal PowerSupply(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }
    public IPowerSupplyBuilder Direct(IPowerSupplyBuilder powerSupplyBuilder)
    {
        powerSupplyBuilder.WithPeakLoad(PeakLoad);
        return powerSupplyBuilder;
    }
}