using System;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class CaseBuilder : ICaseBuilder
{
    private int _heightVideoCard;
    private int _widthVideoCard;
    private FormFactor _motherboardFormFactor;
    private Dimension? _dimension;

    public ICaseBuilder WithHeightVideoCard(int height)
    {
        _heightVideoCard = height;
        return this;
    }

    public ICaseBuilder WithWidthVideoCard(int width)
    {
        _widthVideoCard = width;
        return this;
    }

    public ICaseBuilder WithMotherBoardFormFactor(FormFactor formFactor)
    {
        _motherboardFormFactor = formFactor;
        return this;
    }

    public ICaseBuilder WithDimension(Dimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public ICase Builder()
    {
        return new CaseComputer(
            _heightVideoCard,
            _widthVideoCard,
            _motherboardFormFactor,
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)));
    }
}