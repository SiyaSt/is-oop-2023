using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.DisconnectParse;

public class DisconnectCommandChain : CommandChain
{
    private readonly IDisconnectArgumentChain _parseArgument;
    public DisconnectCommandChain(IDisconnectArgumentChain disconnectArgumentChain)
    {
        _parseArgument = disconnectArgumentChain;
    }

    public override ParseResultTypes Handle(Request request)
    {
        if (request.Command.Current != "disconnect")
        {
            return NextChain is not null ? NextChain.Handle(request) :
                new ParseResultTypes.ErrorCommand("Error command");
        }

        var resultModelBuilder = new DisconnectModel.Builder();
        request.Command.MoveNext();
        ArgumentsResultTypes result = _parseArgument.Handle(request, resultModelBuilder);
        if (result is ArgumentsResultTypes.ErrorResult errorResult)
        {
            return new ParseResultTypes.ErrorCommand(errorResult.Text);
        }

        return new ParseResultTypes.SuccessCommand(new Disconnect(resultModelBuilder.Build()));
    }
}