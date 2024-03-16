using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;
using Itmo.ObjectOrientedProgramming.Lab2.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Validation;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class ComputerBuilder : IComputerBuilder
{
    private readonly IList<IComputerValidation> _computerValidations;
    private IMotherboard? _motherboard;
    private IProcessor? _processor;
    private ICoolerSystem? _coolerSystem;
    private IDdr? _ddr;
    private IVideoCard? _videoCard;
    private ISsd? _ssd;
    private IHdd? _hdd;
    private ICase? _case;
    private IPowerSupply? _powerSupply;
    private IWiFiAdapter? _wiFiAdapter;
    private IXmp? _xmp;

    public ComputerBuilder(IList<IComputerValidation> computerValidations)
    {
        _computerValidations = computerValidations;
    }

    public IComputerBuilder WithMotherBoard(IMotherboard motherboard)
    {
        _motherboard = motherboard as MotherBoard;
        return this;
    }

    public IComputerBuilder WithProcessor(IProcessor processor)
    {
        _processor = processor as Processor.Processor;
        return this;
    }

    public IComputerBuilder WithCoolerSystem(ICoolerSystem coolerSystem)
    {
        _coolerSystem = coolerSystem as CoolerSystem;
        return this;
    }

    public IComputerBuilder WithDdr(IDdr ddr)
    {
        _ddr = ddr as Ddr;
        return this;
    }

    public IComputerBuilder WithVideoCard(IVideoCard? videoCard)
    {
        _videoCard = videoCard as VideoCard.VideoCard;
        return this;
    }

    public IComputerBuilder WithSsd(ISsd? ssd)
    {
        _ssd = ssd as Ssd;
        return this;
    }

    public IComputerBuilder WithHdd(IHdd? hdd)
    {
        _hdd = hdd as Hdd;
        return this;
    }

    public IComputerBuilder WithComputerCase(ICase computerCase)
    {
        _case = computerCase as CaseComputer;
        return this;
    }

    public IComputerBuilder WithPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply as PowerSupply.PowerSupply;
        return this;
    }

    public IComputerBuilder WithWiFiAdapter(IWiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter as WiFiAdapter.WiFiAdapter;
        return this;
    }

    public IComputerBuilder WithXmp(IXmp? xmp)
    {
        _xmp = xmp as Xmp;
        return this;
    }

    public ComputerBuildResultTypes Build()
    {
        if (_motherboard is not null && _processor is not null &&
            _ddr is not null && _case is not null &&
            _coolerSystem is not null && _powerSupply is not null)
        {
            var validationModel = new ValidationModel(
                _motherboard,
                _processor,
                _coolerSystem,
                _ddr,
                _videoCard,
                _ssd,
                _hdd,
                _case,
                _powerSupply,
                _wiFiAdapter,
                _xmp);
            foreach (IComputerValidation validationMethod in _computerValidations)
            {
                ComputerBuildResultTypes result = validationMethod.Validation(validationModel);
                if (result is not ComputerBuildResultTypes.SuccessfulBuild)
                {
                    return result;
                }
            }

            return new ComputerBuildResultTypes.SuccessfulBuild(new Computer(
                _motherboard,
                _processor,
                _coolerSystem,
                _ddr,
                _videoCard,
                _ssd,
                _hdd,
                _case,
                _powerSupply,
                _wiFiAdapter,
                _xmp));
        }

        return new ComputerBuildResultTypes.FailedBuildNotEnoughComponents();
    }
}