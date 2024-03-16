using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class PowerSupplyValidation : IComputerValidation
{
    public ComputerBuildResultTypes Validation(ValidationModel validationModel)
    {
        double power =
            validationModel.Processor.PowerConsumption + validationModel.Ddr.PowerConsumption;
        if (validationModel.Ssd is not null)
        {
            power += validationModel.Ssd.PowerConsumption;
        }

        if (validationModel.Hdd is not null)
        {
            power += validationModel.Hdd.PowerConsumption;
        }

        if (validationModel.VideoCard is not null)
        {
            power += validationModel.VideoCard.PowerConsumption;
        }

        if (validationModel.WiFiAdapter is not null)
        {
            power += validationModel.WiFiAdapter.PowerConsumption;
        }

        double? difference = 100 - ((validationModel.PowerSupply.PeakLoad / power) * 100);
        if (validationModel.PowerSupply.PeakLoad < power && difference > 10)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.PowerSupply, validationModel.PowerSupply);
        }

        if (validationModel.PowerSupply.PeakLoad < power && difference < 10)
        {
            return new ComputerBuildResultTypes.SuccessfulBuildWithCommentary(validationModel.PowerSupply);
        }

        return new ComputerBuildResultTypes.SuccessfulBuild(null);
    }
}