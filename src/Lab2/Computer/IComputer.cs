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

public interface IComputer : IComputerDirect
{
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
}