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

public class Computer : IComputer
{
    internal Computer(
        IMotherboard motherboard,
        IProcessor processor,
        ICoolerSystem coolerSystem,
        IDdr ddr,
        IVideoCard? videoCard,
        ISsd? ssd,
        IHdd? hdd,
        ICase computerCase,
        IPowerSupply powerSupply,
        IWiFiAdapter? wiFiAdapter,
        IXmp? xmp)
    {
        Motherboard = motherboard;
        Processor = processor;
        CoolerSystem = coolerSystem;
        Ddr = ddr;
        VideoCard = videoCard;
        Ssd = ssd;
        Hdd = hdd;
        ComputerCase = computerCase;
        PowerSupply = powerSupply;
        WiFiAdapter = wiFiAdapter;
        Xmp = xmp;
    }

    public IMotherboard Motherboard { get; }
    public IProcessor Processor { get; }
    public ICoolerSystem CoolerSystem { get; }
    public IDdr Ddr { get; }
    public IVideoCard? VideoCard { get; }
    public ISsd? Ssd { get; }
    public IHdd? Hdd { get; }
    public ICase ComputerCase { get; }
    public IPowerSupply PowerSupply { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
    public IXmp? Xmp { get; }
    public IComputerBuilder Direct(IComputerBuilder computerBuilder)
    {
        computerBuilder.WithMotherBoard(Motherboard);
        computerBuilder.WithProcessor(Processor);
        computerBuilder.WithCoolerSystem(CoolerSystem);
        computerBuilder.WithDdr(Ddr);
        computerBuilder.WithVideoCard(VideoCard);
        computerBuilder.WithHdd(Hdd);
        computerBuilder.WithSsd(Ssd);
        computerBuilder.WithComputerCase(ComputerCase);
        computerBuilder.WithPowerSupply(PowerSupply);
        computerBuilder.WithWiFiAdapter(WiFiAdapter);
        computerBuilder.WithXmp(Xmp);
        return computerBuilder;
    }
}