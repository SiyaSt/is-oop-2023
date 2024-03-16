using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class MotherBoardValidation : IComputerValidation
{
    public ComputerBuildResultTypes Validation(ValidationModel validationModel)
    {
        if (validationModel.Motherboard.Bios?.Cpu.Contains(validationModel.Processor) is false)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.Motherboard, validationModel.Processor);
        }

        if (validationModel.Motherboard.ProcessorSocket != validationModel.Processor.ProcessorSocket)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.Motherboard, validationModel.Processor);
        }

        if (validationModel.Motherboard.Ddr?.Version != validationModel.Ddr.Version)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.Motherboard, validationModel.Ddr);
        }

        if (validationModel.Ddr.Xmp?.Contains(validationModel.Motherboard.Chipset?.Xmp) is false)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.Ddr, validationModel.Motherboard);
        }

        if (validationModel.Xmp is not null && validationModel.Motherboard.Chipset?.Xmp != validationModel.Xmp)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.Motherboard, validationModel.Xmp);
        }

        if (validationModel.VideoCard?.PciE != validationModel.Motherboard.PciEVersion)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.VideoCard, validationModel.Motherboard);
        }

        if (validationModel.WiFiAdapter is not null && validationModel.Motherboard.BuiltInWiFi is not null)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.WiFiAdapter, validationModel.Motherboard);
        }

        return new ComputerBuildResultTypes.SuccessfulBuild(null);
    }
}