using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;

public class ConnectAddressChain : ConnectArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, ConnectModel.Builder builder)
    {
        builder.WithAddress(request.Command.Current);
        return NextChain is not null ? NextChain.Handle(request, builder) :
            new ArgumentsResultTypes.ErrorResult("Error command argument");
    }
}