using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;

public interface IFileShowArgumentChain
{
    void AddNextChain(IFileShowArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, FileShowModel.Builder builder);
}