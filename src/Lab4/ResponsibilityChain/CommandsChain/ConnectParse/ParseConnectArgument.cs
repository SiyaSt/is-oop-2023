using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;

public class ParseConnectArgument : ConnectArgumentChain
{
    private readonly IConnectArgumentChain _connectArgumentChain;

    public ParseConnectArgument(IConnectArgumentChain connectArgumentChain)
    {
        _connectArgumentChain = connectArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, ConnectModel.Builder builder)
    {
        var result = new ArgumentsResultTypes();
        while (request.Command.MoveNext())
        {
            result = _connectArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        return result;
    }
}