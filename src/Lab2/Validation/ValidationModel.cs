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

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public record ValidationModel(IMotherboard Motherboard, IProcessor Processor, ICoolerSystem CoolerSystem, IDdr Ddr,
    IVideoCard? VideoCard, ISsd? Ssd, IHdd? Hdd, ICase ComputerCase, IPowerSupply PowerSupply,
    IWiFiAdapter? WiFiAdapter, IXmp? Xmp);
