using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public interface ICaseBuilder
{
    ICaseBuilder WithHeightVideoCard(int height);
    ICaseBuilder WithWidthVideoCard(int width);
    ICaseBuilder WithMotherBoardFormFactor(FormFactor formFactor);
    ICaseBuilder WithDimension(Dimension dimension);

    ICase Builder();
}