using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileDeleteParse;

public abstract class FileDeleteArgumentChain : IFileDeleteArgumentChain
{
    protected IFileDeleteArgumentChain? NextChain { get; private set; }

    public void AddNextChain(IFileDeleteArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, FileDeleteModel.Builder builder);
}