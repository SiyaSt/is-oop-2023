using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;

public class ParseFileShowArgument : FileShowArgumentChain
{
    private readonly IFileShowArgumentChain? _fileShowArgumentChain;

    public ParseFileShowArgument(IFileShowArgumentChain? fileShowArgumentChain)
    {
        _fileShowArgumentChain = fileShowArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, FileShowModel.Builder builder)
    {
        var result = new ArgumentsResultTypes();
        while (request.Command.MoveNext())
        {
            if (_fileShowArgumentChain is null) return new ArgumentsResultTypes.ErrorResult("No chain");
            result = _fileShowArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        return result;
    }
}