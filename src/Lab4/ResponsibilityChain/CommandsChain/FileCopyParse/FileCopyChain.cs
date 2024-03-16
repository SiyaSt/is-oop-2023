using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;

public class FileCopyChain : CommandChain
{
    private readonly IFileCopyArgumentChain _parseArgument;
    private readonly IFileCopyArgumentChain _parseFlag;
    public FileCopyChain(IFileCopyArgumentChain fileCopyArgumentChain, IFileCopyArgumentChain parseFlag)
    {
        _parseArgument = fileCopyArgumentChain;
        _parseFlag = parseFlag;
    }

    public override ParseResultTypes Handle(Request request)
    {
        var resultModelBuilder = new FileCopyModel.Builder();
        if (request.Command.Current != "copy")
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

        return new ParseResultTypes.SuccessCommand(new FileCopy(resultModelBuilder.Build()));
    }
}