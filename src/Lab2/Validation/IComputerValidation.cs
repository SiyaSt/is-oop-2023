using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public interface IComputerValidation
{
    ComputerBuildResultTypes Validation(ValidationModel validationModel);
}