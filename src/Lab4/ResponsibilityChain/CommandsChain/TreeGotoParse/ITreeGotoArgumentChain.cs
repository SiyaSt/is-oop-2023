using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeGotoParse;

public interface ITreeGotoArgumentChain
{
    void AddNextChain(ITreeGotoArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, TreeGotoModel.Builder builder);
}