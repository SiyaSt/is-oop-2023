namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder WithPeakLoad(int peakLoad);
    IPowerSupply Builder();
}