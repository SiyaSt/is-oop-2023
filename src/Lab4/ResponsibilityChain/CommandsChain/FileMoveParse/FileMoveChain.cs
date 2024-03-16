using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;

public class FileMoveChain : CommandChain
{
    private readonly IFileMoveArgumentChain _parseArgument;
    private readonly IFileMoveArgumentChain _parseFlag;
    public FileMoveChain(IFileMoveArgumentChain fileMoveArgumentChain, IFileMoveArgumentChain parseFlag)
    {
        _parseArgument = fileMoveArgumentChain;
        _parseFlag = parseFlag;
    }

    public override ParseResultTypes Handle(Request request)
    {
        var resultModelBuilder = new FileMoveModel.Builder();
        if (request.Command.Current != "move")
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

        return new ParseResultTypes.SuccessCommand(new FileMove(resultModelBuilder.Build()));
    }
}