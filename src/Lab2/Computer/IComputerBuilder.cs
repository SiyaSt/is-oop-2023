using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;
using Itmo.ObjectOrientedProgramming.Lab2.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public interface IComputerBuilder
{
    IComputerBuilder WithMotherBoard(IMotherboard motherboard);
    IComputerBuilder WithProcessor(IProcessor processor);
    IComputerBuilder WithCoolerSystem(ICoolerSystem coolerSystem);
    IComputerBuilder WithDdr(IDdr ddr);
    IComputerBuilder WithVideoCard(IVideoCard? videoCard);
    IComputerBuilder WithSsd(ISsd? ssd);
    IComputerBuilder WithHdd(IHdd? hdd);
    IComputerBuilder WithComputerCase(ICase computerCase);
    IComputerBuilder WithPowerSupply(IPowerSupply powerSupply);
    IComputerBuilder WithWiFiAdapter(IWiFiAdapter? wiFiAdapter);

    IComputerBuilder WithXmp(IXmp? xmp);
    ComputerBuildResultTypes Build();
}