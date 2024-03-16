using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IVideoCard : IComponent, IVideoCardDirect
{
    public Dimension? Dimension { get; }
    public int PciE { get; }
    public int PowerConsumption { get; }
}