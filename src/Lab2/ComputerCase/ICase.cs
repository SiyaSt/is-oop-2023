using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public interface ICase : IComponent, ICaseDirect
{
    public int HeightVideoCard { get; }
    public int WidthVideoCard { get; }
    public FormFactor MotherBoardFormFactor { get; }
    public Dimension? Dimension { get; }
}