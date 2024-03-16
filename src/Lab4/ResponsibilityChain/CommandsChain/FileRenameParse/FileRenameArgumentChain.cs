using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;

public abstract class FileRenameArgumentChain : IFileRenameArgumentChain
{
    protected IFileRenameArgumentChain? NextChain { get; private set; }

    public void AddNextChain(IFileRenameArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, FileRenameModel.Builder builder);
}