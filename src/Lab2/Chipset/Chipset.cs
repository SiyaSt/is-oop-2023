using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Chipset;

public class Chipset : IChipset
{
    internal Chipset(IReadOnlyCollection<int> supportingMemoryFrequency, IXmp? xmp)
    {
        SupportingMemoryFrequency = supportingMemoryFrequency;
        Xmp = xmp;
    }

    public IReadOnlyCollection<int> SupportingMemoryFrequency { get; }
    public IXmp? Xmp { get; }

    public IChipsetBuilder Direct(IChipsetBuilder chipsetBuilder)
    {
        foreach (int memoryFrequency in SupportingMemoryFrequency)
        {
            chipsetBuilder.AddSupportingMemoryFrequency(memoryFrequency);
        }

        chipsetBuilder.WithXmp(Xmp);
        return chipsetBuilder;
    }
}