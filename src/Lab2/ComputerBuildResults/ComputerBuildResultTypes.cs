using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;

public record ComputerBuildResultTypes
{
    public record SuccessfulBuild(IComputer? Computer) : ComputerBuildResultTypes;
    public record SuccessfulBuildWithCommentary(IComponent? Component) : ComputerBuildResultTypes;
    public record BuildWithDisclaimer(IComponent? Component) : ComputerBuildResultTypes;
    public record FailedBuild(IComponent? Component1, IComponent? Component2) : ComputerBuildResultTypes;
    public record FailedBuildNotEnoughComponents() : ComputerBuildResultTypes;
}