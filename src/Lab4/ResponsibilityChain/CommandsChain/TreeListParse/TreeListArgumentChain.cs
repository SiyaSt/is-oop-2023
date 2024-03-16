using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeListParse;

public abstract class TreeListArgumentChain : ITreeListArgumentChain
{
    protected ITreeListArgumentChain? NextChain { get; private set; }

    public void AddNextChain(ITreeListArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, TreeListModel.Builder builder);
}