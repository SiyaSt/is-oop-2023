using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.DOCP;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.DDR;

public class Ddr : IDdr
{
    internal Ddr(int availableMemorySize, int voltage, int frequency, IReadOnlyCollection<IXmp>? xmp, IReadOnlyCollection<IDocp>? docp, string formFactor, string version, int powerConsumption)
    {
        AvailableMemorySize = availableMemorySize;
        Voltage = voltage;
        Frequency = frequency;
        Xmp = xmp;
        Docp = docp;
        FormFactor = formFactor;
        Version = version;
        PowerConsumption = powerConsumption;
    }

    public int AvailableMemorySize { get; }
    public int Voltage { get; }
    public int Frequency { get; }
    public IReadOnlyCollection<IXmp>? Xmp { get; }
    public IReadOnlyCollection<IDocp>? Docp { get; }
    public string FormFactor { get; }
    public string Version { get; }
    public int PowerConsumption { get; }
    public IDdrBuilder Direct(IDdrBuilder ddrBuilder)
    {
        ddrBuilder.WithAvailableMemorySize(AvailableMemorySize);
        ddrBuilder.WithVoltage(Voltage);
        ddrBuilder.WithFrequency(Frequency);
        if (Xmp is not null)
        {
            foreach (IXmp xmp in Xmp)
            {
                ddrBuilder.AddXmp(xmp);
            }
        }

        if (Docp is not null)
        {
            foreach (IDocp docp in Docp)
            {
                ddrBuilder.AddDocp(docp);
            }
        }

        ddrBuilder.WithFormFactor(FormFactor);
        ddrBuilder.WithVersion(Version);
        ddrBuilder.WithPowerConsumption(PowerConsumption);
        return ddrBuilder;
    }
}