using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class CaseComputer : ICase
{
    internal CaseComputer(int heightVideoCard, int widthVideoCard, FormFactor motherBoardFormFactor, Dimension dimension)
    {
        HeightVideoCard = heightVideoCard;
        WidthVideoCard = widthVideoCard;
        MotherBoardFormFactor = motherBoardFormFactor;
        Dimension = dimension;
    }

    public int HeightVideoCard { get; }
    public int WidthVideoCard { get; }
    public FormFactor MotherBoardFormFactor { get; }
    public Dimension Dimension { get; }
    public ICaseBuilder Direct(ICaseBuilder caseBuilder)
    {
        caseBuilder.WithHeightVideoCard(HeightVideoCard);
        caseBuilder.WithWidthVideoCard(WidthVideoCard);
        caseBuilder.WithMotherBoardFormFactor(MotherBoardFormFactor);
        caseBuilder.WithDimension(Dimension);
        return caseBuilder;
    }
}