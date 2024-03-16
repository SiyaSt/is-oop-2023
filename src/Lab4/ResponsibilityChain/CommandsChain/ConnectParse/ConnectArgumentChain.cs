using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;

public abstract class ConnectArgumentChain : IConnectArgumentChain
{
    protected IConnectArgumentChain? NextChain { get; private set; }
    public void AddNextChain(IConnectArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, ConnectModel.Builder builder);
}