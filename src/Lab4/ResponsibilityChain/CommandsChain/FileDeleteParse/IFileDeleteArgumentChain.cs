using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileDeleteParse;

public interface IFileDeleteArgumentChain
{
    void AddNextChain(IFileDeleteArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, FileDeleteModel.Builder builder);
}