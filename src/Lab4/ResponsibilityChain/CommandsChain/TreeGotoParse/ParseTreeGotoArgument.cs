using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeGotoParse;

public class ParseTreeGotoArgument : TreeGotoArgumentChain
{
    private readonly ITreeGotoArgumentChain? _treeGotoArgumentChain;

    public ParseTreeGotoArgument(ITreeGotoArgumentChain? treeGotoArgumentChain)
    {
        _treeGotoArgumentChain = treeGotoArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, TreeGotoModel.Builder builder)
    {
        ArgumentsResultTypes result;
        while (request.Command.MoveNext())
        {
            if (_treeGotoArgumentChain is null) return new ArgumentsResultTypes.ErrorResult("No chain");
            result = _treeGotoArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        result = new ArgumentsResultTypes.SuccessResult();

        return result;
    }
}