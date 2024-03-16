using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;

public interface IFileRenameArgumentChain
{
    void AddNextChain(IFileRenameArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, FileRenameModel.Builder builder);
}