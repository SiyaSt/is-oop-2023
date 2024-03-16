using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Chipset;

public interface IChipsetBuilder
{
    IChipsetBuilder AddSupportingMemoryFrequency(int memoryFrequency);
    IChipsetBuilder WithXmp(IXmp? xmp);
    IChipset Build();
}