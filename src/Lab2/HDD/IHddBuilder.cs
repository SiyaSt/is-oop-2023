namespace Itmo.ObjectOrientedProgramming.Lab2.HDD;

public interface IHddBuilder
{
    IHddBuilder WithSata(string sata);
    IHddBuilder WithMemoryCapacity(int capacity);
    IHddBuilder WithSpindleSpeed(int speed);
    IHddBuilder WithPowerConsumption(int power);
    IHdd Builder();
}