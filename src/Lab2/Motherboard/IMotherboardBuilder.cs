using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithProcessorSocket(string socket);
    IMotherboardBuilder WithPciEAmount(int amount);
    IMotherboardBuilder WithSataAmount(int amount);
    IMotherboardBuilder WithChipset(IChipset chipset);
    IMotherboardBuilder WithDdr(IDdr ddr);
    IMotherboardBuilder WithOzuSlots(int slots);
    IMotherboardBuilder WithFormFactor(FormFactor formFactor);
    IMotherboardBuilder WithBios(IBios? bios);
    IMotherboardBuilder WithBuiltInWiFi(BuiltInWiFi builtInWiFi);
    IMotherboardBuilder WithPciVersion(int version);
    IMotherboard Build();
}