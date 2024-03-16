using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;

public class FileShowChain : CommandChain
{
    private readonly IFileShowArgumentChain _parseArgument;
    private readonly IFileShowArgumentChain _parseFlag;
    public FileShowChain(IFileShowArgumentChain fileShowArgumentChain, IFileShowArgumentChain parseFlag)
    {
        _parseArgument = fileShowArgumentChain;
        _parseFlag = parseFlag;
    }

    public override ParseResultTypes Handle(Request request)
    {
        var resultModelBuilder = new FileShowModel.Builder();
        if (request.Command.Current != "show")
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

        return new ParseResultTypes.SuccessCommand(new FileShow(resultModelBuilder.Build()));
    }
}