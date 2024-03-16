namespace Itmo.ObjectOrientedProgramming.Lab2.DOCP;

public interface IDocpBuilder
{
    IDocpBuilder WithTiming(string timing);
    IDocpBuilder WithVoltage(int voltage);
    IDocpBuilder WithFrequency(int frequency);
    IDocp Builder();
}