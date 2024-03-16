using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class CaseValidation : IComputerValidation
{
    public ComputerBuildResultTypes Validation(ValidationModel validationModel)
    {
        if (validationModel.ComputerCase.MotherBoardFormFactor != validationModel.Motherboard.FormFactor)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.ComputerCase, validationModel.Motherboard);
        }

        if (validationModel.ComputerCase.Dimension?.Width + 30 < validationModel.CoolerSystem.Dimension?.Width)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.CoolerSystem, validationModel.ComputerCase);
        }

        if (validationModel.VideoCard is not null &&
            validationModel.ComputerCase.HeightVideoCard < validationModel.VideoCard.Dimension?.Height &&
            validationModel.ComputerCase.WidthVideoCard < validationModel.VideoCard.Dimension?.Width)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.ComputerCase, validationModel.VideoCard);
        }

        return new ComputerBuildResultTypes.SuccessfulBuild(null);
    }
}