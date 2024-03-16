using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;

public abstract class FileMoveArgumentChain : IFileMoveArgumentChain
{
    protected IFileMoveArgumentChain? NextChain { get; private set; }

    public void AddNextChain(IFileMoveArgumentChain commandChain)
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

    public abstract ArgumentsResultTypes Handle(Request request, FileMoveModel.Builder builder);
}