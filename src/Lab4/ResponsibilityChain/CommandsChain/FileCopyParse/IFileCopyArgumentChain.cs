using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;

public interface IFileCopyArgumentChain
{
    void AddNextChain(IFileCopyArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, FileCopyModel.Builder builder);
}