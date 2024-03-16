using System;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private Dimension? _dimension;
    private int _videoStorageCapacity;
    private int _pciE;
    private int _chipFrequency;
    private int _powerConsumption;
    public IVideoCardBuilder WithDimension(Dimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public IVideoCardBuilder WithVideoStorageCapacity(int capacity)
    {
        _videoStorageCapacity = capacity;
        return this;
    }

    public IVideoCardBuilder WithPciE(int pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int frequency)
    {
        _chipFrequency = frequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int power)
    {
        _powerConsumption = power;
        return this;
    }

    public IVideoCard Builder()
    {
        return new VideoCard(
            _pciE,
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)),
            _videoStorageCapacity,
            _chipFrequency,
            _powerConsumption);
    }
}