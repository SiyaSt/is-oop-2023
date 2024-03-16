using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class DdrValidation : IComputerValidation
{
    public ComputerBuildResultTypes Validation(ValidationModel validationModel)
    {
        if (validationModel.Xmp is not null && validationModel.Ddr.Xmp?.Contains(validationModel.Xmp) is false)
        {
            return new ComputerBuildResultTypes.FailedBuild(validationModel.Ddr, validationModel.Xmp);
        }

        return new ComputerBuildResultTypes.SuccessfulBuild(null);
    }
}