using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ParseResultTypes
{
    public record SuccessCommand(ICommand CommandResult) : ParseResultTypes;
    public record ErrorCommand(string Message) : ParseResultTypes;
}