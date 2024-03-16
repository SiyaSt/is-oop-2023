namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public record MessageIsRead
{
    public record SuccessfulRead() : MessageIsRead;

    public record ErrorRead() : MessageIsRead;
}