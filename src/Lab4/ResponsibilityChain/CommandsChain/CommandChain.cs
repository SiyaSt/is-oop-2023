using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain;

public abstract class CommandChain : ICommandChain
{
    protected ICommandChain? NextChain { get; private set; }

    public void AddNextChain(ICommandChain commandChain)
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

    public abstract ParseResultTypes Handle(Request request);
}