using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class MotherBoard : IMotherboard
{
    internal MotherBoard(string processorSocket, IChipset chipset, IDdr ddr, int ramSlots, FormFactor formFactor, IBios bios, int pciEAmount, int sataAmount, BuiltInWiFi? builtInWiFi, int pciEVersion)
    {
        ProcessorSocket = processorSocket;
        Chipset = chipset;
        Ddr = ddr;
        RamSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
        PciEAmount = pciEAmount;
        SataAmount = sataAmount;
        BuiltInWiFi = builtInWiFi;
        PciEVersion = pciEVersion;
    }

    public string ProcessorSocket { get; }
    public int PciEAmount { get; }

    public int PciEVersion { get; }
    public int SataAmount { get; }
    public IChipset Chipset { get; }
    public IDdr Ddr { get; }
    public int RamSlots { get; }
    public FormFactor FormFactor { get; }
    public IBios Bios { get; }

    public BuiltInWiFi? BuiltInWiFi { get; }
    public IMotherboardBuilder Direct(IMotherboardBuilder motherboardBuilder)
    {
        if (ProcessorSocket is not null)
            motherboardBuilder.WithProcessorSocket(ProcessorSocket);
        motherboardBuilder.WithPciEAmount(PciEAmount);
        motherboardBuilder.WithSataAmount(SataAmount);
        if (Chipset is not null)
            motherboardBuilder.WithChipset(Chipset);
        if (Ddr is not null)
            motherboardBuilder.WithDdr(Ddr);
        motherboardBuilder.WithOzuSlots(RamSlots);
        motherboardBuilder.WithFormFactor(FormFactor);
        motherboardBuilder.WithBios(Bios);
        if (BuiltInWiFi is not null)
            motherboardBuilder.WithBuiltInWiFi(BuiltInWiFi);
        motherboardBuilder.WithPciVersion(PciEVersion);
        return motherboardBuilder;
    }
}