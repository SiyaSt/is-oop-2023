using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class ProcessorValidation : IComputerValidation
{
    public ComputerBuildResultTypes Validation(ValidationModel validationModel)
    {
        if (validationModel.Processor.Tdp > validationModel.CoolerSystem.Tdp)
        {
            return new ComputerBuildResultTypes.BuildWithDisclaimer(validationModel.CoolerSystem);
        }

        if (validationModel.VideoCard is not null && validationModel.Processor.BuiltInVideoCore is not null)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.VideoCard, validationModel.Processor);
        }

        if (validationModel.Processor.BuiltInVideoCore is null && validationModel.VideoCard is null)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.VideoCard, validationModel.Processor);
        }

        return new ComputerBuildResultTypes.SuccessfulBuild(null);
    }
}