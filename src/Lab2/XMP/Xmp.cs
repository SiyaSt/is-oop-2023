namespace Itmo.ObjectOrientedProgramming.Lab2.XMP;

public class Xmp : IXmp
{
    internal Xmp(string timing, int voltage, int frequency)
    {
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timing { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public IXmpBuilder Direct(IXmpBuilder xmpBuilder)
    {
        xmpBuilder.AddTiming(Timing);
        xmpBuilder.AddVoltage(Voltage);
        xmpBuilder.AddFrequency(Frequency);
        return xmpBuilder;
    }
}