using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.DisconnectParse;

public abstract class DisconnectArgumentChain : IDisconnectArgumentChain
{
    protected IDisconnectArgumentChain? NextChain { get; private set; }
    public void AddNextChain(IDisconnectArgumentChain commandChain)
    {
        if (NextChain is null)
        {
            NextChain = commandChain;
        }
        else
        {
            NextChain.AddNextChain(commandChain);
        }
    }

    public abstract ArgumentsResultTypes Handle(Request request, DisconnectModel.Builder builder);
}