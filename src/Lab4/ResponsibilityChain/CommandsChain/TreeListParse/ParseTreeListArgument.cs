using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeListParse;

public class ParseTreeListArgument : TreeListArgumentChain
{
    private readonly ITreeListArgumentChain _treeListArgumentChain;

    public ParseTreeListArgument(ITreeListArgumentChain treeListArgumentChain)
    {
        _treeListArgumentChain = treeListArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, TreeListModel.Builder builder)
    {
        ArgumentsResultTypes result;
        builder.WithDepth(1);
        while (request.Command.MoveNext())
        {
            result = _treeListArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        result = new ArgumentsResultTypes.SuccessResult();
        return result;
    }
}