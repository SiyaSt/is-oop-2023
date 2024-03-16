using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Chipset;

public class ChipsetBuilder : IChipsetBuilder
{
    private readonly IList<int> _memoryFrequency;
    private IXmp? _xmp;

    public ChipsetBuilder()
    {
        _memoryFrequency = new List<int>();
    }

    public IChipsetBuilder AddSupportingMemoryFrequency(int memoryFrequency)
    {
        _memoryFrequency.Add(memoryFrequency);
        return this;
    }

    public IChipsetBuilder WithXmp(IXmp? xmp)
    {
        _xmp = xmp;
        return this;
    }

    public IChipset Build()
    {
        return new Chipset((IReadOnlyCollection<int>)_memoryFrequency, _xmp);
    }
}