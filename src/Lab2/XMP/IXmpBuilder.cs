namespace Itmo.ObjectOrientedProgramming.Lab2.XMP;

public interface IXmpBuilder
{
    IXmpBuilder AddTiming(string timing);
    IXmpBuilder AddVoltage(int voltage);
    IXmpBuilder AddFrequency(int frequency);
    IXmp Builder();
}