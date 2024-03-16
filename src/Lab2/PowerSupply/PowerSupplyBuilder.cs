namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private int _peakLoad;
    public IPowerSupplyBuilder WithPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPowerSupply Builder()
    {
        return new PowerSupply(_peakLoad);
    }
}