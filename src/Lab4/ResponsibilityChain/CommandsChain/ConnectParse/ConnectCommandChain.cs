using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;

public class ConnectCommandChain : CommandChain
{
    private readonly IConnectArgumentChain _parseConnectArgument;
    public ConnectCommandChain(IConnectArgumentChain connectArgumentChain)
    {
        _parseConnectArgument = connectArgumentChain;
    }

    public override ParseResultTypes Handle(Request request)
    {
        if (request.Command.Current != "connect")
        {
            return NextChain is not null ? NextChain.Handle(request) :
                new ParseResultTypes.ErrorCommand("Error command");
        }

        var resultModelBuilder = new ConnectModel.Builder();
        request.Command.MoveNext();
        ArgumentsResultTypes result = _parseConnectArgument.Handle(request, resultModelBuilder);
        if (result is ArgumentsResultTypes.ErrorResult errorResult)
        {
            return new ParseResultTypes.ErrorCommand(errorResult.Text);
        }

        return new ParseResultTypes.SuccessCommand(new Connect(resultModelBuilder.Build()));
    }
}