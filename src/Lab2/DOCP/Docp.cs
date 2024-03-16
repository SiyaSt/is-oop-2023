namespace Itmo.ObjectOrientedProgramming.Lab2.DOCP;

public class Docp : IDocp
{
    internal Docp(string timing, int voltage, int frequency)
    {
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timing { get; }
    public int Voltage { get; }
    public int Frequency { get; }
    public IDocpBuilder Direct(IDocpBuilder docpBuilder)
    {
        docpBuilder.WithTiming(Timing);
        docpBuilder.WithVoltage(Voltage);
        docpBuilder.WithFrequency(Frequency);
        return docpBuilder;
    }
}