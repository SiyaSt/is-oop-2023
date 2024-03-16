using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;

public abstract class FileCopyArgumentChain : IFileCopyArgumentChain
{
    protected IFileCopyArgumentChain? NextChain { get; private set; }

    public void AddNextChain(IFileCopyArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, FileCopyModel.Builder builder);
}