using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class VideoCard : IVideoCard
{
    internal VideoCard(int pciE, Dimension dimension, int videoStorageCapacity, int chipFrequency, int powerConsumption)
    {
        PciE = pciE;
        Dimension = dimension;
        VideoStorageCapacity = videoStorageCapacity;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Dimension Dimension { get; }
    public int VideoStorageCapacity { get; }
    public int PciE { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder.WithDimension(Dimension);
        videoCardBuilder.WithVideoStorageCapacity(VideoStorageCapacity);
        videoCardBuilder.WithPciE(PciE);
        videoCardBuilder.WithChipFrequency(ChipFrequency);
        videoCardBuilder.WithPowerConsumption(PowerConsumption);
        return videoCardBuilder;
    }
}