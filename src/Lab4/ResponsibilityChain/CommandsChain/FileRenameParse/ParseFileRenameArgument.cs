using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;

public class ParseFileRenameArgument : FileRenameArgumentChain
{
    private readonly IFileRenameArgumentChain? _fileRenameArgumentChain;

    public ParseFileRenameArgument(IFileRenameArgumentChain? fileRenameArgumentChain)
    {
        _fileRenameArgumentChain = fileRenameArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, FileRenameModel.Builder builder)
    {
        var result = new ArgumentsResultTypes();
        while (request.Command.MoveNext())
        {
            if (_fileRenameArgumentChain is null) return new ArgumentsResultTypes.ErrorResult("No chain");
            result = _fileRenameArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        return result;
    }
}