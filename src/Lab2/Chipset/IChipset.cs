using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Chipset;

public interface IChipset : IChipsetDirect
{
    public IXmp? Xmp { get; }
}