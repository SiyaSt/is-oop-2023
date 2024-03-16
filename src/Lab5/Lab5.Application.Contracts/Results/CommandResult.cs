namespace Lab5.Application.Contracts.Results;

public record CommandResult
{
    public sealed record Success<T>(T Value) : CommandResult;

    public sealed record ErrorExecution(string Text) : CommandResult;
}