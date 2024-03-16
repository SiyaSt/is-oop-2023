using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithDimension(Dimension dimension);
    IVideoCardBuilder WithVideoStorageCapacity(int capacity);
    IVideoCardBuilder WithPciE(int pciE);
    IVideoCardBuilder WithChipFrequency(int frequency);
    IVideoCardBuilder WithPowerConsumption(int power);
    IVideoCard Builder();
}