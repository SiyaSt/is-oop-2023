using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;

public abstract class FileShowArgumentChain : IFileShowArgumentChain
{
    protected IFileShowArgumentChain? NextChain { get; private set; }

    public void AddNextChain(IFileShowArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, FileShowModel.Builder builder);
}