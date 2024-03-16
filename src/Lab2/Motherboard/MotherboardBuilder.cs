using System;
using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _processorSocket;
    private int _pciEAmount;
    private int _sataAmount;
    private IChipset? _chipset;
    private IDdr? _ddr;
    private int _ozuSlots;
    private FormFactor _formFactor;
    private IBios? _bios;
    private BuiltInWiFi? _builtInWiFi;
    private int _pciEVersion;
    public IMotherboardBuilder WithProcessorSocket(string socket)
    {
        _processorSocket = socket;
        return this;
    }

    public IMotherboardBuilder WithPciEAmount(int amount)
    {
        _pciEAmount = amount;
        return this;
    }

    public IMotherboardBuilder WithSataAmount(int amount)
    {
        _sataAmount = amount;
        return this;
    }

    public IMotherboardBuilder WithChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithDdr(IDdr ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IMotherboardBuilder WithOzuSlots(int slots)
    {
        _ozuSlots = slots;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(IBios? bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder WithBuiltInWiFi(BuiltInWiFi builtInWiFi)
    {
        _builtInWiFi = builtInWiFi;
        return this;
    }

    public IMotherboardBuilder WithPciVersion(int version)
    {
        _pciEVersion = version;
        return this;
    }

    public IMotherboard Build()
    {
        return new MotherBoard(
            _processorSocket ?? throw new ArgumentNullException(nameof(_processorSocket)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _ozuSlots,
            _formFactor,
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _pciEAmount,
            _sataAmount,
            _builtInWiFi,
            _pciEVersion);
    }
}