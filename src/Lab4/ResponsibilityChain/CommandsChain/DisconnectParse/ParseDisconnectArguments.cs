using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.DisconnectParse;

public class ParseDisconnectArguments : DisconnectArgumentChain
{
    private readonly IDisconnectArgumentChain _disconnectArgumentChain;

    public ParseDisconnectArguments(IDisconnectArgumentChain disconnectArgumentChain)
    {
        _disconnectArgumentChain = disconnectArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, DisconnectModel.Builder builder)
    {
        ArgumentsResultTypes result;
        while (request.Command.MoveNext())
        {
            result = _disconnectArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        result = new ArgumentsResultTypes.SuccessResult();

        return result;
    }
}