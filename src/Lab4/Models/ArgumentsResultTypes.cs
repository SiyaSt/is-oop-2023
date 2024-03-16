namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ArgumentsResultTypes
{
    public record SuccessResult : ArgumentsResultTypes;

    public record ErrorResult(string Text) : ArgumentsResultTypes;
}