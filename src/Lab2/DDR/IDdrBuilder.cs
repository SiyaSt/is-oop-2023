using Itmo.ObjectOrientedProgramming.Lab2.DOCP;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.DDR;

public interface IDdrBuilder
{
    IDdrBuilder WithAvailableMemorySize(int size);
    IDdrBuilder WithVoltage(int voltage);
    IDdrBuilder WithFrequency(int frequency);
    IDdrBuilder AddXmp(IXmp? xmp);
    IDdrBuilder AddDocp(IDocp? docp);
    IDdrBuilder WithFormFactor(string formFactor);
    IDdrBuilder WithVersion(string version);
    IDdrBuilder WithPowerConsumption(int power);
    IDdr Build();
}