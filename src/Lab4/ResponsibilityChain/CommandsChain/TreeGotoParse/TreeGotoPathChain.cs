using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeGotoParse;

public class TreeGotoPathChain : TreeGotoArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, TreeGotoModel.Builder builder)
    {
        builder.WithPath(request.Command.Current);
        return new ArgumentsResultTypes.SuccessResult();
    }
}