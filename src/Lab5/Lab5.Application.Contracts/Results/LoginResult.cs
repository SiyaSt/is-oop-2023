namespace Lab5.Application.Contracts.Results;

public record LoginResult
{
    public sealed record Success : LoginResult;

    public sealed record ErrorPin : LoginResult;

    public sealed record NotFound : LoginResult;
}