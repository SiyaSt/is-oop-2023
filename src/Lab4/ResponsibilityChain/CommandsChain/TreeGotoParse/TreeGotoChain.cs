using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeGotoParse;

public class TreeGotoChain : CommandChain
{
    private readonly ITreeGotoArgumentChain _parseArgument;
    private readonly ITreeGotoArgumentChain _parseFlag;
    public TreeGotoChain(ITreeGotoArgumentChain treeGotoArgumentChain, ITreeGotoArgumentChain parseFlag)
    {
        _parseArgument = treeGotoArgumentChain;
        _parseFlag = parseFlag;
    }

    public override ParseResultTypes Handle(Request request)
    {
        var resultModelBuilder = new TreeGotoModel.Builder();

        if (request.Command.Current != "goto")
        {
            return NextChain is not null ? NextChain.Handle(request) :
                new ParseResultTypes.ErrorCommand("Error command");
        }

        request.Command.MoveNext();

        ArgumentsResultTypes result = _parseArgument.Handle(request, resultModelBuilder);
        if (result is ArgumentsResultTypes.ErrorResult errorResultArg)
        {
            return new ParseResultTypes.ErrorCommand(errorResultArg.Text);
        }

        result = _parseFlag.Handle(request, resultModelBuilder);
        if (result is ArgumentsResultTypes.ErrorResult errorResult)
        {
            return new ParseResultTypes.ErrorCommand(errorResult.Text);
        }

        return new ParseResultTypes.SuccessCommand(new TreeGoto(resultModelBuilder.Build()));
    }
}