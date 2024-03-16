using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeListParse;

public interface ITreeListArgumentChain
{
    void AddNextChain(ITreeListArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, TreeListModel.Builder builder);
}