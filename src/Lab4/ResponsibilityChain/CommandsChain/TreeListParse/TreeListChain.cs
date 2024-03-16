using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeListParse;

public class TreeListChain : CommandChain
{
    private readonly ITreeListArgumentChain _parseArgument;
    public TreeListChain(ITreeListArgumentChain treeListArgumentChain)
    {
        _parseArgument = treeListArgumentChain;
    }

    public override ParseResultTypes Handle(Request request)
    {
        var resultModelBuilder = new TreeListModel.Builder();

        if (request.Command.Current != "list")
        {
            return NextChain is not null ? NextChain.Handle(request) :
                new ParseResultTypes.ErrorCommand("Error command");
        }

        ArgumentsResultTypes result = _parseArgument.Handle(request, resultModelBuilder);
        if (result is ArgumentsResultTypes.ErrorResult errorResult)
        {
            return new ParseResultTypes.ErrorCommand(errorResult.Text);
        }

        return new ParseResultTypes.SuccessCommand(new TreeList(resultModelBuilder.Build()));
    }
}