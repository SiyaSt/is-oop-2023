using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain;

public class FileChain : CommandChain
{
    private ICommandChain _commandChain;

    public FileChain(ICommandChain commandChain)
    {
        _commandChain = commandChain;
    }

    public override ParseResultTypes Handle(Request request)
    {
        if (request.Command.Current != "file")
        {
            return NextChain is not null ? NextChain.Handle(request) :
                new ParseResultTypes.ErrorCommand("Error command");
        }

        request.Command.MoveNext();

        return _commandChain.Handle(request);
    }
}