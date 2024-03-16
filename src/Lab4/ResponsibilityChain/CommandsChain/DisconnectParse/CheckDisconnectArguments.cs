using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.DisconnectParse;

public class CheckDisconnectArguments : DisconnectArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, DisconnectModel.Builder builder)
    {
        if (request.Command.MoveNext())
        {
            return new ArgumentsResultTypes.ErrorResult("Error command argument");
        }

        return new ArgumentsResultTypes.SuccessResult();
    }
}