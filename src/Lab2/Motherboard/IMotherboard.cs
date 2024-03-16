using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IComponent, IMotherBoardDirect
{
    public string? ProcessorSocket { get; }
    public int PciEVersion { get; }
    public IChipset? Chipset { get; }
    public IDdr? Ddr { get; }
    public FormFactor FormFactor { get; }
    public IBios? Bios { get; }

    public BuiltInWiFi? BuiltInWiFi { get; }
}