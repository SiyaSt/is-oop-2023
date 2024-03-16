using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;

public class FileRenameChain : CommandChain
{
    private readonly IFileRenameArgumentChain _parseArgument;
    private readonly IFileRenameArgumentChain _parseFlag;
    public FileRenameChain(IFileRenameArgumentChain fileRenameArgumentChain, IFileRenameArgumentChain parseFlag)
    {
        _parseArgument = fileRenameArgumentChain;
        _parseFlag = parseFlag;
    }

    public override ParseResultTypes Handle(Request request)
    {
        var resultModelBuilder = new FileRenameModel.Builder();
        if (request.Command.Current != "rename")
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

        return new ParseResultTypes.SuccessCommand(new FileRename(resultModelBuilder.Build()));
    }
}