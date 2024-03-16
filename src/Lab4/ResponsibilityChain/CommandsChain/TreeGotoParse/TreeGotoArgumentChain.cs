using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeGotoParse;

public abstract class TreeGotoArgumentChain : ITreeGotoArgumentChain
{
    protected ITreeGotoArgumentChain? NextChain { get; private set; }

    public void AddNextChain(ITreeGotoArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, TreeGotoModel.Builder builder);
}