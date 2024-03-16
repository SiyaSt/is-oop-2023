using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;

public interface IFileMoveArgumentChain
{
    void AddNextChain(IFileMoveArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, FileMoveModel.Builder builder);
}