namespace Itmo.ObjectOrientedProgramming.Lab1.Time;

public class Time : ITime
{
    public Time(double timeAmount)
    {
        TimeAmount = timeAmount;
    }

    public double TimeAmount { get; }
}